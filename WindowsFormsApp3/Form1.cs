using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Drawing.Imaging;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Threading.Tasks;
using ScintillaNET;

namespace WindowsFormsApp3
{


    public partial class Form1 : Form
    {
        // Mapeamento de caracteres
        private Dictionary<char, int> characterMapping = new Dictionary<char, int>
        {
            { ' ', 0 }, { 'A', 1 }, { 'B', 2 }, { 'C', 3 }, { 'D', 4 }, { 'E', 5 }, { 'F', 6 }, { 'G', 7 }, { 'H', 8 }, { 'I', 9 }, { 'J', 10 }, { 'K', 11 }, { 'L', 12 }, { 'M', 13 }, { 'N', 14 }, { 'O', 15 }, { 'P', 16 }, { 'Q', 17 }, { 'R', 18 }, { 'S', 19 }, { 'T', 20 }, { 'U', 21 }, { 'V', 22 }, { 'W', 23 }, { 'X', 24 }, { 'Y', 25 }, { 'Z', 26 }, { 'a', 27 }, { 'b', 28 }, { 'c', 29 }, { 'd', 30 }, { 'e', 31 }, { 'f', 32 }, { 'g', 33 }, { 'h', 34 }, { 'i', 35 }, { 'j', 36 }, { 'k', 37 }, { 'l', 38 }, { 'm', 39 }, { 'n', 40 }, { 'o', 41 }, { 'p', 42 }, { 'q', 43 }, { 'r', 44 }, { 's', 45 }, { 't', 46 }, { 'u', 47 }, { 'v', 48 }, { 'w', 49 }, { 'x', 50 }, { 'y', 51 }, { 'z', 52 }, { '0', 53 }, { '1', 54 }, { '2', 55 }, { '3', 56 }, { '4', 57 }, { '5', 58 }, { '6', 59 }, { '7', 60 }, { '8', 61 }, { '9', 62 }, { ',', 63 }, { ';', 64 }, { '.', 65 }, { ':', 66 }, { '!', 67 }, { '?', 68 }, { '\'', 69 }, { '"', 70 }, { '[', 71 }, { ']', 72 }, { '{', 73 }, { '}', 74 }, { '(', 75 }, { ')', 76 }, { '-', 77 }, { '=', 78 }, { '+', 79 }, { '_', 80 }, { '<', 81 }, { '@', 82 }, { '#', 83 }, { '$', 84 }, { '%', 85 }, { '&', 86 }, { '>', 87 }, { '\\', 88 }, { '|', 89 }, { '/', 90 }, { '*', 91 }, { 'Á', 92 }, { 'À', 93 }, { 'Â', 94 }, { 'Ã', 95 }, { 'É', 96 }, { 'Ê', 97 }, { 'Í', 98 }, { 'Ó', 99 }, { 'Ô', 100 }, { 'Õ', 101 }, { 'Ú', 102 }, { 'Ç', 103 }, { 'á', 104 }, { 'à', 105 }, { 'â', 106 }, { 'ã', 107 }, { 'é', 108 }, { 'ê', 109 }, { 'í', 110 }, { 'ó', 111 }, { 'ô', 112 }, { 'õ', 113 }, { 'ú', 114 }, { 'ç', 115 }, { '↔', 116 }
        };

        private Dictionary<char, int> characterWidths = new Dictionary<char, int>();
        private List<int> translatedDialogIndices = new List<int>();
        private Bitmap characterImage;
        private Bitmap referenceImage;
        private int verticalOffset = 0; // Deslocamento vertical
        private int horizontalOffset = 0; // Deslocamento horizontal
        private string caminhoProjetoAtual = @"C:\Caminho\Padrao";
        private string caminhoArquivoTraduzido; // Caminho do arquivo traduzido sendo editado
        private string caminhoTabelaCarregada; // Caminho do arquivo carregado pelo btnLoadTable
        private string caminhoFonteCarregada; // Caminho do arquivo carregado pelo btnLoadImage
        private string caminhoImagemReferencia; // Caminho do arquivo carregado pelo btnLoadReferenceImage
        private string caminhoScriptOriginal; // Caminho do arquivo carregado pelo btnLoadAsm
        private Dictionary<string, string> originalTextMap = new Dictionary<string, string>();
        private Dictionary<string, string> translatedTextMap = new Dictionary<string, string>();
        private List<int> originalDialogIndices = new List<int>();
        private PixelFormat pixelFormatSelecionado = PixelFormat.Format32bppArgb;
        private Dictionary<string, List<string>> labelTextMap = new Dictionary<string, List<string>>();
        private Dictionary<string, string> labelTextMapSingle = new Dictionary<string, string>();
        private Dictionary<string, List<string>> labelTextMapMultiple = new Dictionary<string, List<string>>();
        private List<int> lineVerticalOffsets = new List<int>();
        private List<int> lineHorizontalOffsets = new List<int>();
        private int selectedLineIndex = 0; // Linha selecionada
        private int lineHeight = 16; // Altura padrão de cada linha
        private List<int> lineHorizontalOffsetsPicTranslatedImage = new List<int>();
        private List<int> lineVerticalOffsetsPicTranslatedImage = new List<int>();
        private const int EM_SETOPTIONS = 0x00D8;
        private const int ECOOP_OR = 0x0002;
        private const int ECO_NOHIDESEL = 0x0010;
        private const int WS_HSCROLL = 0x00100000;
        private const int ES_AUTOHSCROLL = 0x0080;
        private const int ES_MULTILINE = 0x0004;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        

        public Form1()
        {
            InitializeComponent();
            ConfigureScintilla();
            ConfigureScintillaColors();
            ConfigureTreeViewColors();
            CarregarConfiguracoes();


            // Vincula o evento KeyDown ao txtTranslatedText
            txtTranslatedText.KeyDown += txtTranslatedText_KeyDown;
            listBox2.MouseDoubleClick += listBox2_MouseDoubleClick;
            numericWidth.Value = texto_renderizado_para_exportar.Width;
            numericHeight.Value = texto_renderizado_para_exportar.Height;


        }


        public class LabelContainer
        {
            public string Content { get; set; } // Conteúdo do label
            public Dictionary<string, LabelContainer> SubLabels { get; set; } // Labels aninhados

            public LabelContainer()
            {
                SubLabels = new Dictionary<string, LabelContainer>();
            }
        }

        private void ConfigureScintilla()
        {
            // Desativar a margem de números de linha
            scintillaEditor.Margins[0].Width = 0;

            // Desativar scroll horizontal e quebra de linha
            scintillaEditor.WrapMode = ScintillaNET.WrapMode.None;
            scintillaEditor.HScrollBar = false;

            // Configurar realce de sintaxe (opcional)
            scintillaEditor.Lexer = ScintillaNET.Lexer.Cpp;

            // Configurar atalhos de teclado manualmente
            scintillaEditor.KeyDown += (sender, e) =>
            {
                if (e.Control && e.KeyCode == Keys.S)
                {
                    // Implementar lógica de salvar aqui
                    MessageBox.Show("Salvar comando ativado!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.SuppressKeyPress = true; // Evita o comportamento padrão
                }
            };
        }





        // Evento para capturar teclas pressionadas no RichTextBox


        private void CarregarConfiguracoes()
        {
            try
            {
                string caminhoConfiguracoes = Path.Combine(Application.StartupPath, "configuracoes.proj");

                if (File.Exists(caminhoConfiguracoes))
                {
                    string json = File.ReadAllText(caminhoConfiguracoes);
                    var configuracoes = JsonConvert.DeserializeObject<dynamic>(json);

                    apiKey = configuracoes.ApiKey != null ? (string)configuracoes.ApiKey : "SUA_CHAVE_DE_API_AQUI";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnLoadTable_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Tabela de Caracteres (*.txt)|*.txt",
                Title = "Carregar Tabela de Caracteres"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Task.Run(() =>
                {
                    try
                    {
                        caminhoTabelaCarregada = openFileDialog.FileName; // Salva o caminho do arquivo
                        string[] lines = File.ReadAllLines(caminhoTabelaCarregada);
                        characterWidths.Clear();
                        foreach (string line in lines)
                        {
                            string[] parts = line.Split('=');
                            if (parts.Length == 2 && parts[0].Length == 1 && int.TryParse(parts[1], out int width))
                            {
                                characterWidths[parts[0][0]] = width;
                            }
                            else
                            {
                                MessageBox.Show($"Linha inválida no arquivo: {line}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a tabela de caracteres: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Obtenha o texto atual do textBox1
            string inputText = textBox1.Text;

            // Formate o texto com base nos delimitadores
            string[] formattedLines = FormatTextByDelimiters(inputText);

            // Atualize o conteúdo do textBox1 com o texto formatado
            textBox1.TextChanged -= textBox1_TextChanged; // Evita loops infinitos
            textBox1.Text = string.Join(Environment.NewLine, formattedLines);
            textBox1.TextChanged += textBox1_TextChanged;

            // Mova o cursor para o final do texto
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }


        


        

       

        private void SalvarConfiguracoes()
        {
            try
            {
                string caminhoConfiguracoes = Path.Combine(Application.StartupPath, "configuracoes.proj");

                var configuracoes = new
                {
                    ApiKey = apiKey,
                    // Outros campos podem ser adicionados aqui
                };

                string json = JsonConvert.SerializeObject(configuracoes, Formatting.Indented);
                File.WriteAllText(caminhoConfiguracoes, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Certifique-se de que a variável apiKey seja declarada como um campo da classe
        private string apiKey = "SUA_CHAVE_DE_API_AQUI"; // Valor inicial padrão




        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Imagens PNG (*.png)|*.png",
                Title = "Carregar Imagem de Caracteres"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    caminhoFonteCarregada = openFileDialog.FileName; // Salva o caminho do arquivo
                    characterImage = new Bitmap(caminhoFonteCarregada);
                    picTranslatedImage.Image = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void txtTranslatedText_TextChanged(object sender, EventArgs e)
        {
            AtualizarCorTexto();
            if (referenceImage == null || characterImage == null || characterWidths.Count == 0)
            {
                return; // Certifique-se de que todos os recursos necessários estão carregados
            }

            try
            {
                if (string.IsNullOrWhiteSpace(txtTranslatedText.Text))
                {
                    picTranslatedImage.Image = null; // Limpa a imagem se o texto estiver vazio
                    texto_renderizado_para_exportar.Image = null; // Limpa a imagem de exportação também
                    return;
                }

                // Atualiza os valores de lineHeight
                lineHeight = (int)numericLineHeight.Value;

                // Filtrar o texto para renderizar apenas o conteúdo entre aspas
                var linhas = txtTranslatedText.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                List<string> textoFiltrado = new List<string>();
                foreach (string linha in linhas)
                {
                    var matches = Regex.Matches(linha, "\"(.*?)\"");
                    foreach (Match match in matches)
                    {
                        textoFiltrado.Add(match.Groups[1].Value);
                    }
                }

                // Atualiza os deslocamentos verticais e horizontais das linhas para picTranslatedImage
                lineVerticalOffsets.Clear();
                lineHorizontalOffsets.Clear();

                for (int i = 0; i < textoFiltrado.Count; i++)
                {
                    lineVerticalOffsets.Add(i * lineHeight); // Adiciona deslocamento vertical
                    lineHorizontalOffsets.Add(0); // Inicializa com deslocamento horizontal independente

                }

                // Renderiza o texto na janela picTranslatedImage (usando os deslocamentos globais)
                RenderizarTexto(textoFiltrado);

                // Renderiza o texto na janela de exportação (sem usar os deslocamentos globais)
                RenderizarTextoParaExportarSemOffsets(textoFiltrado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a pré-visualização: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void RenderizarTextoParaExportarSemOffsets(List<string> textoParaRenderizar)
        {
            try
            {
                if (characterImage == null || characterWidths.Count == 0)
                {
                    MessageBox.Show("Certifique-se de que a tabela de caracteres e a imagem foram carregadas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Configurações de renderização
                int totalWidth = texto_renderizado_para_exportar.Width;
                int totalHeight = texto_renderizado_para_exportar.Height;
                Bitmap renderedImage = new Bitmap(totalWidth, totalHeight, pixelFormatSelecionado);

                using (Graphics g = Graphics.FromImage(renderedImage))
                {
                    g.Clear(texto_renderizado_para_exportar.BackColor);

                    for (int i = 0; i < textoParaRenderizar.Count; i++)
                    {
                        int x = 0; // Sem deslocamento horizontal
                        int y = i * lineHeight; // Apenas o deslocamento baseado na altura da linha

                        foreach (char c in textoParaRenderizar[i])
                        {
                            if (characterWidths.ContainsKey(c) && characterMapping.ContainsKey(c))
                            {
                                int charWidth = characterWidths[c];
                                int charIndex = characterMapping[c];
                                int sourceX = (charIndex % 8) * 16;
                                int sourceY = (charIndex / 8) * 16;

                                if (sourceX + charWidth > characterImage.Width || sourceY + 16 > characterImage.Height)
                                {
                                    continue;
                                }

                                Rectangle sourceRect = new Rectangle(sourceX, sourceY, charWidth, 16);
                                Rectangle destRect = new Rectangle(x, y, charWidth, 16);

                                g.DrawImage(characterImage, destRect, sourceRect, GraphicsUnit.Pixel);
                                x += charWidth;
                            }
                        }
                    }
                }

                texto_renderizado_para_exportar.Image = renderedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao renderizar o texto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void RenderizarTexto(List<string> textoParaRenderizar)
        {
            try
            {
                if (characterImage == null || referenceImage == null)
                {
                    MessageBox.Show("Certifique-se de que a imagem de caracteres e a imagem de referência foram carregadas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Configurações de renderização
                int totalWidth = picTranslatedImage.Width;
                int totalHeight = picTranslatedImage.Height;
                Bitmap renderedImage = new Bitmap(totalWidth, totalHeight, PixelFormat.Format32bppArgb);

                using (Graphics g = Graphics.FromImage(renderedImage))
                {
                    g.Clear(Color.Transparent); // Limpa a área de renderização

                    // Desenhar a imagem de referência centralizada
                    float scaleFactor = (float)picTranslatedImage.Height / referenceImage.Height;
                    int scaledWidth = (int)(referenceImage.Width * scaleFactor);
                    int scaledHeight = picTranslatedImage.Height;
                    int refX = (picTranslatedImage.Width - scaledWidth) / 2;

                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(referenceImage, refX, 0, scaledWidth, scaledHeight);

                    // Renderizar o texto
                    for (int i = 0; i < textoParaRenderizar.Count; i++)
                    {
                        int x = refX + horizontalOffset; // Respeita o deslocamento horizontal
                        int y = verticalOffset + (i * lineHeight); // Respeita o deslocamento vertical e altura da linha

                        foreach (char c in textoParaRenderizar[i])
                        {
                            if (characterWidths.ContainsKey(c) && characterMapping.ContainsKey(c))
                            {
                                int charWidth = characterWidths[c];
                                int charIndex = characterMapping[c];
                                int sourceX = (charIndex % 8) * 16;
                                int sourceY = (charIndex / 8) * 16;

                                if (sourceX + charWidth > characterImage.Width || sourceY + 16 > characterImage.Height)
                                {
                                    continue;
                                }

                                Rectangle sourceRect = new Rectangle(sourceX, sourceY, charWidth, 16);
                                Rectangle destRect = new Rectangle(x, y, charWidth, 16);

                                g.DrawImage(characterImage, destRect, sourceRect, GraphicsUnit.Pixel);
                                x += charWidth;
                            }
                        }
                    }
                }

                picTranslatedImage.Image = renderedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao renderizar o texto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void BtnLoadReferenceImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Imagens PNG (*.png)|*.png",
                Title = "Carregar Imagem de Referência"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    caminhoImagemReferencia = openFileDialog.FileName; // Salva o caminho do arquivo
                    referenceImage = new Bitmap(caminhoImagemReferencia);

                    // Calcular o fator de escala para preencher a altura do controle
                    float scaleFactor = (float)picTranslatedImage.Height / referenceImage.Height;
                    int scaledWidth = (int)(referenceImage.Width * scaleFactor);
                    int scaledHeight = picTranslatedImage.Height;

                    // Criar um bitmap escalonado
                    Bitmap scaledImage = new Bitmap(scaledWidth, scaledHeight);
                    using (Graphics g = Graphics.FromImage(scaledImage))
                    {
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; // Sem suavização
                        g.DrawImage(referenceImage, 0, 0, scaledWidth, scaledHeight);
                    }

                    // Centralizar a imagem escalonada no controle
                    Bitmap centeredImage = new Bitmap(picTranslatedImage.Width, picTranslatedImage.Height);
                    using (Graphics g = Graphics.FromImage(centeredImage))
                    {
                        g.Clear(Color.Transparent);

                        int x = (picTranslatedImage.Width - scaledWidth) / 2;
                        g.DrawImage(scaledImage, x, 0, scaledWidth, scaledHeight);
                    }

                    picTranslatedImage.Image = centeredImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar a imagem de referência: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        private void BtnCima_Click(object sender, EventArgs e)
        {
            verticalOffset -= 8; // Move o texto 8 pixels para cima
            txtTranslatedText_TextChanged(sender, e); // Atualiza a renderização
        }

        private void BtnBaixo_Click(object sender, EventArgs e)
        {
            verticalOffset += 8; // Move o texto 8 pixels para baixo
            txtTranslatedText_TextChanged(sender, e); // Atualiza a renderização
        }

        private void BtnEsquerda_Click(object sender, EventArgs e)
        {
            horizontalOffset -= 8; // Move o texto 8 pixels para a esquerda
            txtTranslatedText_TextChanged(sender, e); // Atualiza a renderização
        }

        private void BtnDireita_Click(object sender, EventArgs e)
        {
            horizontalOffset += 8; // Move o texto 8 pixels para a direita
            txtTranslatedText_TextChanged(sender, e); // Atualiza a renderização
        }

        

        

        

        








        

        private void txtRenderTextLabel_TextChanged(object sender, EventArgs e)
        {

        }

        
     

        private void BtnSalvarScriptTraduzido_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(caminhoArquivoTraduzido))
            {
                try
                {
                    // Verifica se há um label selecionado no listBox1
                    if (listBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Nenhum label selecionado. Por favor, selecione um label antes de salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Obtém o label selecionado
                    string selectedLabel = listBox1.SelectedItem.ToString().TrimEnd(':');

                    // Atualiza o texto do label selecionado com o conteúdo do txtTranslatedText
                    if (translatedTextMap.ContainsKey(selectedLabel))
                    {
                        translatedTextMap[selectedLabel] = txtTranslatedText.Text;
                    }
                    else
                    {
                        MessageBox.Show("O label selecionado não foi encontrado no mapa de textos traduzidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Detecta sub-labels no texto do txtTranslatedText
                    var subLabelMatches = Regex.Matches(txtTranslatedText.Text, @"^[a-zA-Z_]+\d+:", RegexOptions.Multiline);
                    foreach (Match match in subLabelMatches)
                    {
                        string subLabel = match.Value.TrimEnd(':');
                        if (!translatedTextMap.ContainsKey(subLabel))
                        {
                            // Adiciona o sub-label ao mapa com texto vazio inicialmente
                            translatedTextMap[subLabel] = string.Empty;
                        }
                    }

                    // Lista para armazenar o conteúdo do arquivo
                    List<string> fileContent = new List<string>();

                    // Itera sobre os labels e seus textos para salvar no arquivo
                    foreach (var label in translatedTextMap.Keys)
                    {
                        // Adiciona o label ao arquivo
                        fileContent.Add($"{label}:");

                        // Adiciona o texto correspondente ao label
                        string translatedContent = translatedTextMap[label];
                        var lines = translatedContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        foreach (var line in lines)
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                fileContent.Add(line);
                            }
                        }
                    }

                    // Salva o conteúdo no arquivo
                    File.WriteAllText(caminhoArquivoTraduzido, string.Join(Environment.NewLine, fileContent));

                    // Recarrega o arquivo traduzido para garantir a ordem correta dos labels
                    CarregarScriptTraduzido(caminhoArquivoTraduzido);

                    MessageBox.Show("Script traduzido salvo e recarregado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar o script traduzido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nenhum arquivo traduzido foi carregado pelo botão 'Carregar Script Traduzido'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void BtnGravarConfiguracoes_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Arquivo de Projeto (*.proj)|*.proj",
                    Title = "Salvar Configurações"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cria um objeto com todas as informações solicitadas
                    var configuracoes = new
                    {
                        CaminhoNovoScript = caminhoScriptOriginal, // Salva o caminho do script carregado pelo btnCarregarNovoScript
                        CaminhoScriptTraduzido = caminhoArquivoTraduzido, // btnCarregarScriptTraduzido
                        CaminhoTabela = caminhoTabelaCarregada, // btnLoadTable
                        CaminhoImagemFonte = caminhoFonteCarregada, // btnLoadImage
                        CaminhoImagemReferencia = caminhoImagemReferencia, // btnLoadReferenceImage
                        CorDeFundo = texto_renderizado_para_exportar.BackColor.ToArgb(), // btnCorDeFundo

                        // Novos estados a serem armazenados
                        NumericTextHorizontalOffset = numericTextHorizontalOffset.Value,
                        NumericTextVerticalOffset = numericTextVerticalOffset.Value,
                        NumericLineHeight = numericLineHeight.Value,
                        ComboBoxCodecs = comboBoxCodecs.SelectedItem?.ToString(),
                        NumericWidth = numericWidth.Value,
                        NumericHeight = numericHeight.Value,
                        NumericHorizontalOffset = numericHorizontalOffset.Value,
                        NumericVerticalOffset = numericVerticalOffset.Value,
                        ApiKey = apiKey,
                        // Adicionando os novos campos
                        TextBox27 = textBox27.Text,
                        TextBox19 = textBox19.Text,
                        TextBox20 = textBox20.Text,
                        TextBox21 = textBox21.Text,
                        TextBox26 = textBox26.Text,
                        TextBox25 = textBox25.Text,
                        TextBox24 = textBox24.Text,
                        ComboBox1 = comboBox1.SelectedItem?.ToString(),
                        ComboBox2 = comboBox2.SelectedItem?.ToString(),
                        ComboBox3 = comboBox3.SelectedItem?.ToString(),
                        ComboBox4 = comboBox4.SelectedItem?.ToString(),
                        ComboBox5 = comboBox5.SelectedItem?.ToString(),
                        ComboBox6 = comboBox6.SelectedItem?.ToString(),
                        ComboBox7 = comboBox7.SelectedItem?.ToString(),
                        // Adicionando as seleções dos ComboBoxes
                        ComboBox1Selecionado = comboBox1.SelectedItem?.ToString(),
                        ComboBox2Selecionado = comboBox2.SelectedItem?.ToString(),
                        ComboBox3Selecionado = comboBox3.SelectedItem?.ToString(),
                        ComboBox4Selecionado = comboBox4.SelectedItem?.ToString(),
                        ComboBox5Selecionado = comboBox5.SelectedItem?.ToString(),
                        ComboBox6Selecionado = comboBox6.SelectedItem?.ToString(),
                        ComboBox7Selecionado = comboBox7.SelectedItem?.ToString() // Renomeado para evitar duplicação
                    };

                    // Serializa o objeto para JSON
                    string json = JsonConvert.SerializeObject(configuracoes, Formatting.Indented);

                    // Salva o JSON no arquivo selecionado
                    File.WriteAllText(saveFileDialog.FileName, json);

                    MessageBox.Show("Configurações gravadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CarregarProjeto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivo de Projeto (*.proj)|*.proj",
                Title = "Carregar Projeto"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var projeto = JsonConvert.DeserializeObject<dynamic>(json);

                    // Carregar o caminho do script original (CaminhoNovoScript)
                    caminhoScriptOriginal = projeto.CaminhoNovoScript;
                    if (!string.IsNullOrEmpty(caminhoScriptOriginal))
                    {
                        CarregarScriptOriginal(caminhoScriptOriginal);
                    }

                    // Carregar outros recursos
                    caminhoTabelaCarregada = projeto.CaminhoTabela;
                    if (!string.IsNullOrEmpty(caminhoTabelaCarregada))
                    {
                        CarregarTabelaDeCaracteres(caminhoTabelaCarregada);
                    }

                    caminhoFonteCarregada = projeto.CaminhoImagemFonte;
                    if (!string.IsNullOrEmpty(caminhoFonteCarregada))
                    {
                        CarregarImagemDeFonte(caminhoFonteCarregada);
                    }

                    caminhoArquivoTraduzido = projeto.CaminhoScriptTraduzido;
                    if (!string.IsNullOrEmpty(caminhoArquivoTraduzido))
                    {
                        CarregarScriptTraduzido(caminhoArquivoTraduzido);
                    }

                    // Restaurar outras configurações
                    horizontalOffset = projeto.HorizontalOffset != null ? int.Parse((string)projeto.HorizontalOffset) : 0;
                    verticalOffset = projeto.VerticalOffset != null ? int.Parse((string)projeto.VerticalOffset) : 0;

                    // Restaurar os novos estados
                    numericTextHorizontalOffset.Value = projeto.NumericTextHorizontalOffset != null ? (decimal)projeto.NumericTextHorizontalOffset : 0;
                    numericTextVerticalOffset.Value = projeto.NumericTextVerticalOffset != null ? (decimal)projeto.NumericTextVerticalOffset : 0;
                    numericLineHeight.Value = projeto.NumericLineHeight != null ? (decimal)projeto.NumericLineHeight : 16;
                    comboBoxCodecs.SelectedItem = projeto.ComboBoxCodecs != null ? (string)projeto.ComboBoxCodecs : null;
                    numericWidth.Value = projeto.NumericWidth != null ? (decimal)projeto.NumericWidth : texto_renderizado_para_exportar.Width;
                    numericHeight.Value = projeto.NumericHeight != null ? (decimal)projeto.NumericHeight : texto_renderizado_para_exportar.Height;
                    numericHorizontalOffset.Value = projeto.NumericHorizontalOffset != null ? (decimal)projeto.NumericHorizontalOffset : 0;
                    numericVerticalOffset.Value = projeto.NumericVerticalOffset != null ? (decimal)projeto.NumericVerticalOffset : 0;
                    apiKey = projeto.ApiKey != null ? (string)projeto.ApiKey : "SUA_CHAVE_DE_API_AQUI";
                    // Restaurar os valores dos ComboBoxes
                    comboBox1.SelectedItem = projeto.ComboBox1Selecionado != null ? (string)projeto.ComboBox1Selecionado : null;
                    comboBox2.SelectedItem = projeto.ComboBox2Selecionado != null ? (string)projeto.ComboBox2Selecionado : null;
                    comboBox3.SelectedItem = projeto.ComboBox3Selecionado != null ? (string)projeto.ComboBox3Selecionado : null;
                    comboBox4.SelectedItem = projeto.ComboBox4Selecionado != null ? (string)projeto.ComboBox4Selecionado : null;
                    comboBox5.SelectedItem = projeto.ComboBox5Selecionado != null ? (string)projeto.ComboBox5Selecionado : null;
                    comboBox6.SelectedItem = projeto.ComboBox6Selecionado != null ? (string)projeto.ComboBox6Selecionado : null;
                    comboBox7.SelectedItem = projeto.ComboBox7 != null ? (string)projeto.ComboBox7 : null;

                    // Restaurando os novos campos
                    textBox27.Text = projeto.TextBox27 ?? string.Empty;
                    textBox19.Text = projeto.TextBox19 ?? string.Empty;
                    textBox20.Text = projeto.TextBox20 ?? string.Empty;
                    textBox21.Text = projeto.TextBox21 ?? string.Empty;
                    textBox26.Text = projeto.TextBox26 ?? string.Empty;
                    textBox25.Text = projeto.TextBox25 ?? string.Empty;
                    textBox24.Text = projeto.TextBox24 ?? string.Empty;

                    // Restaurar a cor de fundo
                    texto_renderizado_para_exportar.BackColor = projeto.CorDeFundo != null ? Color.FromArgb((int)projeto.CorDeFundo) : Color.White;

                    // Carregar a imagem de referência por último
                    caminhoImagemReferencia = projeto.CaminhoImagemReferencia;
                    if (!string.IsNullOrEmpty(caminhoImagemReferencia))
                    {
                        CarregarImagemDeReferencia(caminhoImagemReferencia);
                    }

                    caminhoProjetoAtual = Path.GetDirectoryName(projeto.CaminhoNovoScript);



                    MessageBox.Show($"Projeto {projeto.NomeProjeto} carregado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar o projeto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void BtnCarregarConfiguracao_Click(object sender, EventArgs e)
        {
            CarregarProjeto();
        }



        private void CarregarTabelaDeCaracteres(string caminho)
        {
            try
            {
                string[] lines = File.ReadAllLines(caminho);
                characterWidths.Clear();
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2 && parts[0].Length == 1 && int.TryParse(parts[1], out int width))
                    {
                        characterWidths[parts[0][0]] = width;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a tabela de caracteres: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarImagemDeFonte(string caminho)
        {
            try
            {
                characterImage = new Bitmap(caminho);
                picTranslatedImage.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a imagem de fonte: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarImagemDeReferencia(string caminho)
        {
            try
            {
                referenceImage = new Bitmap(caminho);
                caminhoImagemReferencia = caminho; // Salva o caminho do arquivo

                // Calcular o fator de escala para preencher a altura do controle
                float scaleFactor = (float)picTranslatedImage.Height / referenceImage.Height;
                int scaledWidth = (int)(referenceImage.Width * scaleFactor);
                int scaledHeight = picTranslatedImage.Height;

                // Criar um bitmap escalonado
                Bitmap scaledImage = new Bitmap(scaledWidth, scaledHeight);
                using (Graphics g = Graphics.FromImage(scaledImage))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; // Sem suavização
                    g.DrawImage(referenceImage, 0, 0, scaledWidth, scaledHeight);
                }

                // Centralizar a imagem escalonada no controle
                Bitmap centeredImage = new Bitmap(picTranslatedImage.Width, picTranslatedImage.Height);
                using (Graphics g = Graphics.FromImage(centeredImage))
                {
                    g.Clear(Color.Transparent);

                    int x = (picTranslatedImage.Width - scaledWidth) / 2;
                    g.DrawImage(scaledImage, x, 0, scaledWidth, scaledHeight);
                }

                picTranslatedImage.Image = centeredImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a imagem de referência: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CarregarScriptOriginal(string caminho)
        {
            try
            {
                string[] lines = File.ReadAllLines(caminho);
                novoScriptMap.Clear();
                string currentLabel = null;

                foreach (string line in lines)
                {
                    if (Regex.IsMatch(line.Trim(), @"^[a-zA-Z_]+\d+:$"))
                    {
                        currentLabel = line.TrimEnd(':').Trim();
                        if (!novoScriptMap.ContainsKey(currentLabel))
                        {
                            novoScriptMap[currentLabel] = string.Empty;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(line) && currentLabel != null)
                    {
                        novoScriptMap[currentLabel] += line + Environment.NewLine;
                    }
                }

                // Atualizar o listBox2 com os labels carregados
                listBox2.Items.Clear();
                foreach (var label in novoScriptMap.Keys)
                {
                    listBox2.Items.Add(label + ":");
                    // Adiciona os sub-labels associados
                    var subLabels = Regex.Matches(novoScriptMap[label], @"^[a-zA-Z_]+\d+:$", RegexOptions.Multiline);
                    foreach (Match subLabel in subLabels)
                    {
                        listBox2.Items.Add("    " + subLabel.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o script original: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void CarregarScriptTraduzido(string caminho)
        {
            try
            {
                string[] lines = File.ReadAllLines(caminho);
                translatedTextMap.Clear();
                string currentLabel = null;

                foreach (string line in lines)
                {
                    if (Regex.IsMatch(line.Trim(), @"^[a-zA-Z_]+\d+:$"))
                    {
                        currentLabel = line.TrimEnd(':').Trim();
                        if (!translatedTextMap.ContainsKey(currentLabel))
                        {
                            translatedTextMap[currentLabel] = string.Empty;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(line) && currentLabel != null)
                    {
                        translatedTextMap[currentLabel] += line + Environment.NewLine;
                    }
                }

                listBox1.Items.Clear();
                foreach (var label in translatedTextMap.Keys)
                {
                    listBox1.Items.Add(label + ":");
                    // Adiciona os sub-labels associados
                    var subLabels = Regex.Matches(translatedTextMap[label], @"^[a-zA-Z_]+\d+:$", RegexOptions.Multiline);
                    foreach (Match subLabel in subLabels)
                    {
                        listBox1.Items.Add("    " + subLabel.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o script traduzido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnNovoProjeto_Click(object sender, EventArgs e)
        {
            // Exibir uma caixa de diálogo de confirmação
            var resultado = MessageBox.Show(
                "Tem certeza de que deseja limpar tudo e criar um novo projeto?",
                "Confirmar Novo Projeto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Verificar a resposta do usuário
            if (resultado == DialogResult.Yes)
            {
                ResetarEstadoOriginal(); // Chama o método para resetar os estados
            }
        }



        private void RenderizarTextoParaExportar()
        {
            try
            {
                if (characterImage == null || characterWidths.Count == 0)
                {
                    MessageBox.Show("Certifique-se de que a tabela de caracteres e a imagem foram carregadas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTranslatedText.Text))
                {
                    texto_renderizado_para_exportar.Image = null; // Limpa a imagem se o texto estiver vazio
                    return;
                }

                // Extrair apenas o conteúdo dentro de aspas duplas
                var linhas = txtTranslatedText.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                List<string> textoFiltrado = new List<string>();
                foreach (string linha in linhas)
                {
                    var matches = Regex.Matches(linha, "\"(.*?)\"");
                    foreach (Match match in matches)
                    {
                        textoFiltrado.Add(match.Groups[1].Value);
                    }
                }

                // Ajustar o número de linhas nos deslocamentos
                while (lineVerticalOffsets.Count < textoFiltrado.Count)
                {
                    lineVerticalOffsets.Add(0); // Adiciona deslocamentos padrão
                    lineHorizontalOffsets.Add(0);
                }

                while (lineVerticalOffsets.Count > textoFiltrado.Count)
                {
                    lineVerticalOffsets.RemoveAt(lineVerticalOffsets.Count - 1);
                    lineHorizontalOffsets.RemoveAt(lineHorizontalOffsets.Count - 1);
                }

                // Configurações de renderização
                int totalWidth = texto_renderizado_para_exportar.Width;
                int totalHeight = texto_renderizado_para_exportar.Height;
                Bitmap renderedImage = new Bitmap(totalWidth, totalHeight, pixelFormatSelecionado);

                using (Graphics g = Graphics.FromImage(renderedImage))
                {
                    g.Clear(texto_renderizado_para_exportar.BackColor);

                    for (int i = 0; i < textoFiltrado.Count; i++)
                    {
                        int x = lineHorizontalOffsets[i]; // Usa o deslocamento horizontal específico da linha
                        int y = lineVerticalOffsets[i]; // Usa o deslocamento vertical calculado

                        foreach (char c in textoFiltrado[i])
                        {
                            if (characterWidths.ContainsKey(c) && characterMapping.ContainsKey(c))
                            {
                                int charWidth = characterWidths[c];
                                int charIndex = characterMapping[c];
                                int sourceX = (charIndex % 8) * 16;
                                int sourceY = (charIndex / 8) * 16;

                                if (sourceX + charWidth > characterImage.Width || sourceY + 16 > characterImage.Height)
                                {
                                    continue;
                                }

                                Rectangle sourceRect = new Rectangle(sourceX, sourceY, charWidth, 16);
                                Rectangle destRect = new Rectangle(x, y, charWidth, 16); // Mantém o tamanho fixo do texto

                                g.DrawImage(characterImage, destRect, sourceRect, GraphicsUnit.Pixel);
                                x += charWidth;
                            }
                        }
                    }
                }

                texto_renderizado_para_exportar.Image = renderedImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao renderizar o texto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void NumericHorizontalOffset_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLineIndex >= 0 && selectedLineIndex < lineHorizontalOffsets.Count)
            {
                // Atualiza apenas o deslocamento horizontal da linha selecionada
                lineHorizontalOffsets[selectedLineIndex] = (int)numericHorizontalOffset.Value;
                RenderizarTextoParaExportar(); // Atualiza a renderização
            }
        }




        private void NumericVerticalOffset_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLineIndex >= 0 && selectedLineIndex < lineVerticalOffsets.Count)
            {
                // Atualiza apenas o deslocamento vertical de texto_renderizado_para_exportar
                lineVerticalOffsets[selectedLineIndex] = (int)numericVerticalOffset.Value;
                RenderizarTextoParaExportar(); // Atualiza apenas o texto_renderizado_para_exportar
            }
        }



        private void NumericSelectedLine_ValueChanged(object sender, EventArgs e)
        {
            selectedLineIndex = (int)numericSelectedLine.Value - 1; // Ajusta para índice zero
            if (selectedLineIndex >= 0 && selectedLineIndex < lineHorizontalOffsets.Count)
            {
                // Atualiza os valores exibidos nos controles com base nos deslocamentos da linha selecionada
                numericHorizontalOffset.Value = lineHorizontalOffsets[selectedLineIndex];
                numericVerticalOffset.Value = lineVerticalOffsets[selectedLineIndex];
            }
        }






        private void NumericLineHeight_ValueChanged(object sender, EventArgs e)
        {
            lineHeight = (int)numericLineHeight.Value;

            // Atualiza os deslocamentos verticais das linhas com base no novo lineHeight
            for (int i = 0; i < lineVerticalOffsets.Count; i++)
            {
                lineVerticalOffsets[i] = i * lineHeight;
            }

            // Re-renderiza o texto com os novos deslocamentos
            RenderizarTextoParaExportar();
        }





        private void BtnCorDeFundo_Click(object sender, EventArgs e)
        {
            // Altera o cursor para o conta-gotas
            Cursor = Cursors.Cross;

            // Ativa o evento de clique no PictureBox
            picTranslatedImage.MouseClick += PicTranslatedImage_MouseClick;
        }


        private void PicTranslatedImage_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Verifica se há uma imagem carregada no PictureBox
                if (picTranslatedImage.Image == null)
                {
                    MessageBox.Show("Nenhuma imagem carregada na janela 'PREVIEW INGAME'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Converte as coordenadas do clique para o espaço da imagem
                Bitmap bitmap = new Bitmap(picTranslatedImage.Image);
                int x = (int)(e.X * ((float)bitmap.Width / picTranslatedImage.Width));
                int y = (int)(e.Y * ((float)bitmap.Height / picTranslatedImage.Height));

                // Garante que as coordenadas estão dentro dos limites da imagem
                if (x >= 0 && x < bitmap.Width && y >= 0 && y < bitmap.Height)
                {
                    // Obtém a cor do pixel clicado
                    Color corSelecionada = bitmap.GetPixel(x, y);

                    // Define a cor de fundo do texto_renderizado_para_exportar
                    texto_renderizado_para_exportar.BackColor = corSelecionada;

                    // Atualiza a renderização para refletir a nova cor de fundo
                    RenderizarTextoParaExportar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar a cor: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Remove o evento para evitar múltiplas assinaturas
                picTranslatedImage.MouseClick -= PicTranslatedImage_MouseClick;

                // Restaura o cursor para a seta padrão
                Cursor = Cursors.Default;
            }
        }



        private void BtnExportBinary_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há uma imagem renderizada no PictureBox
                if (texto_renderizado_para_exportar.Image == null)
                {
                    MessageBox.Show("Nenhuma imagem renderizada encontrada para exportar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Converte a imagem do PictureBox para um Bitmap
                Bitmap renderedImage = new Bitmap(texto_renderizado_para_exportar.Image);

                // Abre o diálogo para salvar o arquivo binário
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Arquivo Binário (*.bin)|*.bin",
                    Title = "Exportar Binário"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Converte o Bitmap em dados binários
                    List<byte> binaryData = new List<byte>();

                    // Percorre os pixels da imagem
                    for (int y = 0; y < renderedImage.Height; y++)
                    {
                        for (int x = 0; x < renderedImage.Width; x++)
                        {
                            // Obtém a cor do pixel
                            Color pixelColor = renderedImage.GetPixel(x, y);

                            
                        }
                    }

                    // Salva os dados binários no arquivo
                    File.WriteAllBytes(saveFileDialog.FileName, binaryData.ToArray());
                    MessageBox.Show("Arquivo binário exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar o arquivo binário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportPng_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há uma imagem renderizada no PictureBox
                if (texto_renderizado_para_exportar.Image == null)
                {
                    MessageBox.Show("Nenhuma imagem renderizada encontrada para exportar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Usa os valores de numericWidth e numericHeight para definir a área de recorte
                int exportWidth = (int)numericWidth.Value;
                int exportHeight = (int)numericHeight.Value;

                // Cria um novo Bitmap com as dimensões exatas da área de recorte
                Bitmap croppedImage = new Bitmap(exportWidth, exportHeight);

                using (Graphics g = Graphics.FromImage(croppedImage))
                {
                    // Preenche o fundo com a cor de fundo do controle
                    g.Clear(texto_renderizado_para_exportar.BackColor);

                    // Copia a área correspondente da imagem renderizada sem escalonamento
                    g.DrawImage(
                        (Bitmap)texto_renderizado_para_exportar.Image,
                        new Rectangle(0, 0, exportWidth, exportHeight),
                        new Rectangle(0, 0, exportWidth, exportHeight),
                        GraphicsUnit.Pixel
                    );
                }

                // Abre o diálogo para salvar o arquivo de imagem
                using (SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Imagem PNG (*.png)|*.png",
                    Title = "Exportar Imagem"
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Salva a imagem final no formato PNG
                        croppedImage.Save(saveFileDialog.FileName, ImageFormat.Png);
                        MessageBox.Show("Imagem exportada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private void ResetarEstadoOriginal()
        {
            // Limpar campos de texto
            txtOriginalText.Text = string.Empty;
            txtTranslatedText.Text = string.Empty;

            // Limpar imagens
            picTranslatedImage.Image = null;
            texto_renderizado_para_exportar.Image = null;
            characterImage = null;
            referenceImage = null;

            // Resetar offsets
            horizontalOffset = 0;
            verticalOffset = 0;

            // Limpar listas e mapas
            originalTextMap.Clear();
            translatedTextMap.Clear();
            labelTextMap.Clear();
            novoScriptMap.Clear();
            characterWidths.Clear();
            lineVerticalOffsets.Clear();
            lineHorizontalOffsets.Clear();

            // Resetar controles numéricos
            numericTextHorizontalOffset.Value = 0;
            numericTextVerticalOffset.Value = 0;
            numericHorizontalOffset.Value = 0;
            numericVerticalOffset.Value = 0;
            numericSelectedLine.Value = 1;
            numericLineHeight.Value = 16;

            // Resetar ComboBoxes
            comboBoxCodecs.SelectedIndex = -1;
            comboBoxDimensoes.SelectedIndex = -1;

            // Resetar caminhos
            caminhoProjetoAtual = string.Empty;
            caminhoArquivoTraduzido = string.Empty;
            caminhoTabelaCarregada = string.Empty;
            caminhoFonteCarregada = string.Empty;
            caminhoImagemReferencia = string.Empty;
            caminhoScriptOriginal = string.Empty;

            // Resetar cores e outros estados
            texto_renderizado_para_exportar.BackColor = Color.FromArgb(53, 53, 53);
            this.BackColor = Color.FromArgb(64, 64, 64);

            // Limpar ListBoxes
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            MessageBox.Show("Todos os estados foram resetados para o original.", "Novo Projeto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCarregarScriptTraduzido_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivos de Script (*.txt;*.asm;*.xml;*.yaml)|*.txt;*.asm;*.xml;*.yaml|Todos os Arquivos (*.*)|*.*",
                Title = "Carregar Script Traduzido"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Salva o caminho do arquivo traduzido carregado
                    caminhoArquivoTraduzido = openFileDialog.FileName;

                    // Lê todas as linhas do arquivo traduzido
                    string[] lines = File.ReadAllLines(caminhoArquivoTraduzido);

                    // Dicionário para mapear labels e seus textos
                    translatedTextMap.Clear();
                    string currentLabel = null;

                    foreach (string line in lines)
                    {
                        // Verifica se a linha é um label (prefixo+numeros+:)
                        if (Regex.IsMatch(line.Trim(), @"^[a-zA-Z_]+\d+:$"))
                        {
                            currentLabel = line.TrimEnd(':').Trim();

                            // Adiciona o label ao dicionário com texto vazio inicialmente
                            if (!translatedTextMap.ContainsKey(currentLabel))
                            {
                                translatedTextMap[currentLabel] = string.Empty;
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(line) && currentLabel != null)
                        {
                            // Adiciona o texto ao label atual
                            translatedTextMap[currentLabel] += line + Environment.NewLine;
                        }
                    }

                    // Atualiza o listBox1 com os labels encontrados
                    listBox1.Items.Clear();
                    foreach (var label in translatedTextMap.Keys)
                    {
                        listBox1.Items.Add(label + ":");
                    }

                    MessageBox.Show("Labels do script traduzido carregados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar o script traduzido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Obtém o label selecionado
                string selectedLabel = listBox1.SelectedItem.ToString().TrimEnd(':');

                // Exibe o texto correspondente no txtTranslatedText
                if (translatedTextMap.ContainsKey(selectedLabel))
                {
                    txtTranslatedText.Text = translatedTextMap[selectedLabel];
                }
                else
                {
                    txtTranslatedText.Text = string.Empty;
                }

                // Renderizar o texto na picTranslatedImage
                var linhas = txtTranslatedText.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // Filtrar o texto para renderizar apenas o conteúdo entre aspas
                List<string> textoFiltrado = new List<string>();
                foreach (string linha in linhas)
                {
                    var matches = Regex.Matches(linha, "\"(.*?)\"");
                    foreach (Match match in matches)
                    {
                        textoFiltrado.Add(match.Groups[1].Value);
                    }
                }

                // Renderizar o texto usando os valores atuais de deslocamento
                horizontalOffset = (int)numericTextHorizontalOffset.Value;
                verticalOffset = (int)numericTextVerticalOffset.Value;
                RenderizarTexto(textoFiltrado);
            }
        }



        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string itemText = listBox1.Items[e.Index].ToString();
            e.DrawBackground();

            Brush textBrush;
            if (IsMainLabel(itemText)) // Verifica se é um label principal
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(43, 43, 43)), e.Bounds); // Fundo cinza muito escuro
                textBrush = new SolidBrush(Color.FromArgb(255, 255, 225)); // Texto com cor RGB (53, 53, 53)

            }
            else if (IsSubLabel(itemText)) // Verifica se é um sublabel
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, e.Bounds); // Fundo azul para seleção
                    textBrush = Brushes.White; // Texto branco
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(53, 53, 53)), e.Bounds); // Fundo com cor RGB (53, 53, 53)
                    textBrush = Brushes.White; // Texto branco
                }
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds); // Fundo branco
                textBrush = Brushes.Black; // Texto preto
            }

            e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string itemText = listBox2.Items[e.Index].ToString();
            e.DrawBackground();

            Brush textBrush;
            if (IsMainLabel(itemText)) // Verifica se é um label principal
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(43, 43, 43)), e.Bounds); // Fundo cinza muito escuro
                textBrush = new SolidBrush(Color.FromArgb(255, 255, 225)); // Texto com cor RGB (53, 53, 53)
            }
            else if (IsSubLabel(itemText)) // Verifica se é um sublabel
            {
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.Blue, e.Bounds); // Fundo azul para seleção
                    textBrush = Brushes.White; // Texto branco
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(53, 53, 53)), e.Bounds); // Fundo com cor RGB (53, 53, 53)
                    textBrush = Brushes.White; // Texto branco
                }
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds); // Fundo branco
                textBrush = Brushes.Black; // Texto preto
            }

            e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds);
            e.DrawFocusRectangle();
        }


        // Lógica para identificar se é um label principal
        private bool IsMainLabel(string label)
        {
            // Regex para dois prefixos seguidos de números e ":"
            return Regex.IsMatch(label, @"^[a-zA-Z_]+_[a-zA-Z_]+_\d{4}:$");
        }

        // Lógica para identificar se é um sublabel
        private bool IsSubLabel(string label)
        {
            // Regex para um prefixo seguido de números e ":"
            return Regex.IsMatch(label, @"^[a-zA-Z_]+_\d{4}:$");
        }






        private void BtnCarregarNovoScript_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivos de Script (*.txt;*.asm;*.xml;*.yaml)|*.txt;*.asm;*.xml;*.yaml|Todos os Arquivos (*.*)|*.*",
                Title = "Carregar Novo Script"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminho = openFileDialog.FileName;
                CarregarScript(caminho);
            }
        }




        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedLabel = listBox2.SelectedItem.ToString().TrimEnd(':');

                // Verifica se o label selecionado existe no dicionário
                if (novoScriptMap.ContainsKey(selectedLabel))
                {
                    // Obtém o texto do label selecionado
                    string originalText = novoScriptMap[selectedLabel];

                    // Extrai apenas o conteúdo dentro de aspas duplas
                    var matches = Regex.Matches(originalText, @"""([^""]*)""");

                    // Junta todo o texto extraído
                    StringBuilder extractedText = new StringBuilder();
                    foreach (Match match in matches)
                    {
                        extractedText.Append(match.Groups[1].Value + " ");
                    }

                    // Formata o texto para exibição com base nos delimitadores (!, ?, .)
                    string[] formattedLines = FormatTextByDelimiters(extractedText.ToString().Trim());

                    // Exibe o texto formatado no TextBox txtOriginalText
                    txtOriginalText.Text = string.Join(Environment.NewLine, formattedLines);
                }
                else
                {
                    txtOriginalText.Text = "Texto não encontrado para o label selecionado.";
                }

                // Garante que txtTranslatedText e picTranslatedImage não sejam alterados
                // Nenhuma lógica aqui deve afetar txtTranslatedText ou picTranslatedImage
            }
        }





        private void txtOriginalText_TextChanged_Alternate(object sender, EventArgs e)
        {
            // Implementation for the second method
        }



        private string[] FormatTextByDelimiters(string text)
        {
            List<string> lines = new List<string>();
            StringBuilder currentLine = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                // Adiciona o caractere atual à linha
                currentLine.Append(text[i]);

                // Verifica se encontrou reticências
                if (i + 2 < text.Length && text[i] == '.' && text[i + 1] == '.' && text[i + 2] == '.')
                {
                    currentLine.Append(".."); // Adiciona os dois pontos restantes
                    lines.Add(currentLine.ToString().Trim());
                    currentLine.Clear();
                    i += 2; // Avança o índice para pular os dois pontos adicionais
                }
                // Verifica se encontrou um ponto isolado
                else if (text[i] == '.' && (i + 2 >= text.Length || text[i + 1] != '.' || text[i + 2] != '.'))
                {
                    lines.Add(currentLine.ToString().Trim());
                    currentLine.Clear();
                }
                // Verifica se encontrou ! ou ?
                else if (text[i] == '!' || text[i] == '?')
                {
                    lines.Add(currentLine.ToString().Trim());
                    currentLine.Clear();
                }
            }

            // Adiciona qualquer texto restante como uma nova linha
            if (currentLine.Length > 0)
            {
                lines.Add(currentLine.ToString().Trim());
            }

            return lines.ToArray();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedLabel = listBox1.SelectedItem.ToString().TrimEnd(':');

                // Procura o mesmo label principal na listBox2
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    if (listBox2.Items[i].ToString().TrimEnd(':') == selectedLabel)
                    {
                        listBox2.SelectedIndex = i; // Seleciona o item correspondente
                        listBox2.TopIndex = i; // Move o cursor para o item
                        break;
                    }
                }
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string selectedLabel = listBox2.SelectedItem.ToString().TrimEnd(':');

                // Procura o mesmo label principal na listBox1
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString().TrimEnd(':') == selectedLabel)
                    {
                        listBox1.SelectedIndex = i; // Seleciona o item correspondente
                        listBox1.TopIndex = i; // Move o cursor para o item
                        break;
                    }
                }
            }
        }


        private void BtnExportarCodec_Click(object sender, EventArgs e)
        {
            if (texto_renderizado_para_exportar.Image == null)
            {
                MessageBox.Show("Nenhuma imagem renderizada para exportar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxCodecs.SelectedItem == null)
            {
                MessageBox.Show("Selecione um codec antes de exportar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            

            string selectedCodec = comboBoxCodecs.SelectedItem.ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivo Binário (*.bin)|*.bin",
                Title = "Salvar Imagem como Binário"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = saveFileDialog.FileName;
                string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_export.png");

                try
                {
                    // 1. Exportar o renderizado para PNG
                    ExportRenderedImageToPng(tempPngPath);

                    // 2. Converter o PNG para binário com base nas configurações
                    if (selectedCodec == "2bpp planar")
                    {
                        ConvertPngTo2Bpp(tempPngPath, outputPath, "2D", false);
                    }
                    else
                    {
                        MessageBox.Show($"Codec '{selectedCodec}' não suportado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // 3. Apagar o PNG temporário
                    if (File.Exists(tempPngPath))
                    {
                        try
                        {
                            File.Delete(tempPngPath);
                        }
                        catch (IOException ioEx)
                        {
                            throw new Exception($"Erro ao excluir o arquivo temporário: {ioEx.Message}");
                        }
                    }
                }

                MessageBox.Show("Exportação concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        private void ExportRenderedImageToPng(string pngPath)
        {
            try
            {
                // Certifique-se de que a imagem não está nula
                if (texto_renderizado_para_exportar.Image == null)
                {
                    throw new Exception("Nenhuma imagem renderizada disponível para exportação.");
                }

                // Cria uma cópia do Bitmap para evitar bloqueios
                using (Bitmap renderedImage = new Bitmap(texto_renderizado_para_exportar.Image))
                {
                    // Salva a cópia no caminho especificado
                    renderedImage.Save(pngPath, ImageFormat.Png);
                }
            }
            catch (ExternalException ex)
            {
                throw new Exception($"Erro ao exportar para PNG: O arquivo pode estar em uso ou bloqueado. Detalhes: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao exportar para PNG: {ex.Message}");
            }
        }





        private void ConvertPngTo2Bpp(string inputPngPath, string outputBinPath, string dimension, bool isInterleaved)
        {
            using (Bitmap bitmap = new Bitmap(inputPngPath))
            {
                int tileWidth = 8;
                int tileHeight = 8;
                int blockWidth = 16; // Número de tiles por linha no modo 2D

                if (bitmap.Width % tileWidth != 0 || bitmap.Height % tileHeight != 0)
                {
                    throw new ArgumentException("A largura e altura da imagem devem ser múltiplas de 8 para exportação em 2bpp planar.");
                }

                using (FileStream fs = new FileStream(outputBinPath, FileMode.Create, FileAccess.Write))
                {
                    for (int ty = 0; ty < bitmap.Height; ty += tileHeight)
                    {
                        for (int tx = 0; tx < bitmap.Width; tx += tileWidth)
                        {
                            byte[] tileData = new byte[tileHeight * 2]; // Cada linha do tile tem 2 bytes (plane0 + plane1)

                            for (int y = 0; y < tileHeight; y++)
                            {
                                if (ty + y >= bitmap.Height) break;

                                byte plane0 = 0;
                                byte plane1 = 0;

                                for (int x = 0; x < tileWidth; x++)
                                {
                                    if (tx + x >= bitmap.Width) break;

                                    Color pixel = bitmap.GetPixel(tx + x, ty + y);
                                    int colorIndex = GetColorIndex(pixel); // Mapeia a cor para um índice (0-3)

                                    // Extrai os bits do índice de cor
                                    int bit0 = (colorIndex >> 0) & 1;
                                    int bit1 = (colorIndex >> 1) & 1;

                                    // Preenche os bits nos planos
                                    plane0 |= (byte)(bit0 << (7 - x));
                                    plane1 |= (byte)(bit1 << (7 - x));
                                }

                                // Adiciona os planos ao tile
                                tileData[y * 2] = plane0;
                                tileData[y * 2 + 1] = plane1;
                            }

                            // Organização 1D ou 2D
                            if (dimension == "2D")
                            {
                                int tileIndex = (ty / tileHeight) * (bitmap.Width / tileWidth) + (tx / tileWidth); // Índice do tile na imagem
                                int blockIndex = (tileIndex / blockWidth) * blockWidth * tileHeight * 2; // Índice do bloco
                                int tileOffset = (tileIndex % blockWidth) * tileHeight * 2; // Offset do tile dentro do bloco

                                fs.Seek(blockIndex + tileOffset, SeekOrigin.Begin);
                                fs.Write(tileData, 0, tileData.Length);
                            }
                            else
                            {
                                // Organização 1D: escreve sequencialmente
                                fs.Write(tileData, 0, tileData.Length);
                            }
                        }
                    }
                }

                // Aplica interleaving, se necessário
                if (isInterleaved)
                {
                    ApplyInterleavedLogic(outputBinPath, dimension == "2D");
                }
            }
        }



        private void ApplyInterleavedLogic(string filePath, bool is2D)
        {
            byte[] data = File.ReadAllBytes(filePath);

            if (!is2D)
            {
                // Lógica para interleaving no modo 1D
                byte[] interleavedData = new byte[data.Length];
                int halfLength = data.Length / 2;

                for (int i = 0; i < halfLength; i++)
                {
                    interleavedData[i * 2] = data[i]; // Primeiro plano
                    interleavedData[i * 2 + 1] = data[halfLength + i]; // Segundo plano
                }

                File.WriteAllBytes(filePath, interleavedData);
            }
            else
            {
                // Lógica para interleaving no modo 2D
                int tileSize = 16; // Cada tile tem 16 bytes (8 linhas * 2 planos)
                int numTiles = data.Length / tileSize;
                byte[] interleavedData = new byte[data.Length];

                for (int tileIndex = 0; tileIndex < numTiles; tileIndex++)
                {
                    int baseIndex = tileIndex * tileSize;

                    for (int line = 0; line < 8; line++) // 8 linhas por tile
                    {
                        interleavedData[baseIndex + line * 2] = data[baseIndex + line]; // Primeiro plano
                        interleavedData[baseIndex + line * 2 + 1] = data[baseIndex + 8 + line]; // Segundo plano
                    }
                }

                File.WriteAllBytes(filePath, interleavedData);
            }
        }




        private readonly List<Color> colorPalette = new List<Color>
{
    Color.FromArgb(0, 0, 0),       // Preto (cor de fundo)
    Color.FromArgb(139, 69, 19),   // Marrom avermelhado
    Color.FromArgb(218, 165, 32),  // Dourado
    Color.FromArgb(255, 255, 128)  // Amarelo claro
};


        


        private void Export1BppPlanarWithOptions(Image image, string dimension, string outputPath)
        {
            Bitmap bitmap = new Bitmap(image);

            if (bitmap.Width % 8 != 0)
            {
                throw new ArgumentException("A largura da imagem deve ser múltipla de 8 para exportação em 1bpp planar.");
            }

            int widthInBytes = bitmap.Width / 8;
            int height = bitmap.Height;
            byte[] plane = new byte[widthInBytes * height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    int grayValue = (pixel.R + pixel.G + pixel.B) / 3;
                    int bit = grayValue > 127 ? 1 : 0;

                    int byteIndex = (y * widthInBytes) + (x / 8);
                    int bitIndex = 7 - (x % 8);

                    if (bit == 1)
                    {
                        plane[byteIndex] |= (byte)(1 << bitIndex);
                    }
                }
            }

            

            File.WriteAllBytes(outputPath, plane);
        }

        





        


        private int GetColorIndex(Color color)
        {
            // Procura a cor mais próxima na paleta
            int closestIndex = 0;
            double closestDistance = double.MaxValue;

            for (int i = 0; i < colorPalette.Count; i++)
            {
                Color paletteColor = colorPalette[i];
                double distance = Math.Sqrt(
                    Math.Pow(color.R - paletteColor.R, 2) +
                    Math.Pow(color.G - paletteColor.G, 2) +
                    Math.Pow(color.B - paletteColor.B, 2)
                );

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }

            return closestIndex;
        }

        private bool isDragging = false;
        private Point dragStartPoint = Point.Empty;

        private void PictureBoxMovel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = e.Location; // Armazena o ponto inicial do clique
            }
        }

        private void PictureBoxMovel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calcula o novo local do PictureBox
                var pictureBox = sender as PictureBox;
                pictureBox.Left += e.X - dragStartPoint.X;
                pictureBox.Top += e.Y - dragStartPoint.Y;
            }
        }

        private void PictureBoxMovel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false; // Para o movimento
            }
        }

        private void NumericWidth_ValueChanged(object sender, EventArgs e)
        {
            // Ajusta a largura do controle texto_renderizado_para_exportar
            texto_renderizado_para_exportar.Width = (int)numericWidth.Value;
        }

        private void NumericHeight_ValueChanged(object sender, EventArgs e)
        {
            // Ajusta a altura do controle texto_renderizado_para_exportar
            texto_renderizado_para_exportar.Height = (int)numericHeight.Value;
        }



        private Stack<string> undoStack = new Stack<string>();



        private void txtTranslatedText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                if (undoStack.Count > 1) // Garante que há algo para desfazer
                {
                    redoStack.Push(undoStack.Pop()); // Move o estado atual para a pilha de refazer
                    txtTranslatedText.TextChanged -= txtTranslatedText_TextChanged; // Desativa o evento temporariamente
                    txtTranslatedText.Text = undoStack.Peek(); // Restaura o estado anterior
                    txtTranslatedText.TextChanged += txtTranslatedText_TextChanged; // Reativa o evento
                }
                e.SuppressKeyPress = true; // Evita o comportamento padrão
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.Z)
            {
                if (redoStack.Count > 0) // Garante que há algo para refazer
                {
                    undoStack.Push(redoStack.Pop()); // Move o estado do refazer de volta para a pilha de desfazer
                    txtTranslatedText.TextChanged -= txtTranslatedText_TextChanged; // Desativa o evento temporariamente
                    txtTranslatedText.Text = undoStack.Peek(); // Restaura o estado
                    txtTranslatedText.TextChanged += txtTranslatedText_TextChanged; // Reativa o evento
                }
                e.SuppressKeyPress = true; // Evita o comportamento padrão
            }
        }


        private Stack<string> redoStack = new Stack<string>();

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 1) // Garante que há algo para desfazer
            {
                // Move o estado atual para a pilha de refazer
                redoStack.Push(undoStack.Pop());

                // Restaura o estado anterior
                txtTranslatedText.Text = undoStack.Peek();
            }
            else
            {
                MessageBox.Show("Nada para desfazer.", "Desfazer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void BtnRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0) // Garante que há algo para refazer
            {
                // Move o estado do refazer de volta para a pilha de desfazer
                undoStack.Push(redoStack.Pop());

                // Restaura o estado
                txtTranslatedText.Text = undoStack.Peek();
            }
            else
            {
                MessageBox.Show("Nada para refazer.", "Refazer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void NumericTextHorizontalOffset_ValueChanged(object sender, EventArgs e)
        {
            // Atualiza apenas o deslocamento horizontal de picTranslatedImage
            horizontalOffset = (int)numericTextHorizontalOffset.Value;
            AtualizarRenderizacaoPicTranslatedImage(); // Atualiza apenas o picTranslatedImage
        }


        private void NumericTextVerticalOffset_ValueChanged(object sender, EventArgs e)
        {
            // Atualiza apenas o deslocamento vertical de picTranslatedImage
            verticalOffset = (int)numericTextVerticalOffset.Value;
            AtualizarRenderizacaoPicTranslatedImage(); // Atualiza apenas o picTranslatedImage
        }



        private void AtualizarRenderizacaoPicTranslatedImage()
        {
            if (!string.IsNullOrWhiteSpace(txtTranslatedText.Text))
            {
                // Filtra o texto para renderizar apenas o conteúdo entre aspas
                var linhas = txtTranslatedText.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                List<string> textoFiltrado = new List<string>();
                foreach (string linha in linhas)
                {
                    var matches = Regex.Matches(linha, "\"(.*?)\"");
                    foreach (Match match in matches)
                    {
                        textoFiltrado.Add(match.Groups[1].Value);
                    }
                }

                // Renderiza apenas no picTranslatedImage
                RenderizarTexto(textoFiltrado);
            }
            else
            {
                picTranslatedImage.Image = null; // Limpa a imagem se o texto estiver vazio
            }
        }






        private void AtualizarTextoRenderizado(int horizontalOffset, int verticalOffset)
        {
            using (Graphics g = picTranslatedImage.CreateGraphics())
            {
                g.Clear(picTranslatedImage.BackColor); // Limpar a imagem anterior
                string texto = txtTranslatedText.Text;
                using (Font fonte = new Font("Arial", 12))
                using (Brush pincel = Brushes.Black)
                {
                    g.DrawString(texto, fonte, pincel, horizontalOffset, verticalOffset);
                }
            }
        }

        private void txtPreviewLabel_TextChanged(object sender, EventArgs e)
        {

        }

        


        private void ComboBoxDimensoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dimensaoSelecionada = comboBoxDimensoes.SelectedItem.ToString();
            // Adicione aqui a lógica para "1 Dimensão" ou "2 Dimensões", se necessário
        }







        private void AtualizarCorTexto()
        {
            // Salva a posição atual do cursor e a seleção
            int selectionStart = txtTranslatedText.SelectionStart;
            int selectionLength = txtTranslatedText.SelectionLength;

            // Obtém o texto atual
            string textoAtual = txtTranslatedText.Text;

            // Aplica as cores para cada linha e sua respectiva cor
            foreach (var textBoxComboBoxPair in new[]
            {
        (textBox: textBox19, comboBox: comboBox2),
        (textBox: textBox20, comboBox: comboBox3),
        (textBox: textBox21, comboBox: comboBox4),
        (textBox: textBox24, comboBox: comboBox5),
        (textBox: textBox25, comboBox: comboBox6),
        (textBox: textBox26, comboBox: comboBox7),
        (textBox: textBox27, comboBox: comboBox1)
    })
            {
                ApplyTextColor(textBoxComboBoxPair.textBox, textBoxComboBoxPair.comboBox, textoAtual);
            }

            // Restaura a posição do cursor e a seleção
            txtTranslatedText.Select(selectionStart, selectionLength);
        }

        private void ApplyTextColor(TextBox textBox, ComboBox comboBox, string textoAtual)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text)) return;

            // Divide as palavras separadas por ';' e remove espaços extras
            string[] keywords = textBox.Text.Split(';').Select(k => k.Trim()).Where(k => !string.IsNullOrEmpty(k)).ToArray();
            Color color = GetColorFromComboBox(comboBox);

            foreach (string keyword in keywords)
            {
                int startIndex = 0;

                // Procura todas as ocorrências da palavra-chave no texto
                while ((startIndex = textoAtual.IndexOf(keyword, startIndex, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    txtTranslatedText.Select(startIndex, keyword.Length);
                    txtTranslatedText.SelectionColor = color;
                    startIndex += keyword.Length; // Avança o índice para evitar loop infinito
                }
            }
        }



        private void txtNovoCampo_TextChanged(object sender, EventArgs e)
        {
            AtualizarCorTexto();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarCorTexto();
        }


        private Color GetColorFromComboBox(ComboBox comboBox)
        {
            string selectedItem = comboBox.SelectedItem?.ToString();
            switch (selectedItem)
            {
                case "Preto":
                    return Color.Black;
                case "Marrom":
                    return Color.Brown;
                case "Dourado":
                    return Color.Gold;
                case "Amarelo Claro":
                    return Color.LightYellow;
                case "Vermelho":
                    return Color.Red;
                case "Verde":
                    return Color.Green;
                case "Azul":
                    return Color.Blue;
                case "Branco":
                    return Color.White;
                case "Cinza":
                    return Color.Gray;
                case "Rosa":
                    return Color.Pink;
                case "Laranja":
                    return Color.Orange;
                case "Roxo":
                    return Color.Purple;
                case "Ciano":
                    return Color.Cyan;
                case "Magenta":
                    return Color.Magenta;
                case "Verde Limão":
                    return Color.Lime;
                case "Azul Claro":
                    return Color.LightBlue;
                case "Amarelo Ouro":
                    return Color.Yellow;
                case "Marinho":
                    return Color.Navy;
                case "Azeitona":
                    return Color.Olive;
                case "Turquesa":
                    return Color.Turquoise;
                case "Chocolate":
                    return Color.Chocolate;
                case "Coral":
                    return Color.Coral;
                case "Lavanda":
                    return Color.Lavender;
                case "Bege":
                    return Color.Beige;
                case "Prata":
                    return Color.Silver;
                case "Dourado Escuro":
                    return Color.DarkGoldenrod;
                case "Verde Escuro":
                    return Color.DarkGreen;
                case "Azul Escuro":
                    return Color.DarkBlue;
                case "Vermelho Escuro":
                    return Color.DarkRed;
                case "Rosa Escuro":
                    return Color.DeepPink;
                case "Ciano Escuro":
                    return Color.DarkCyan;
                default:
                    return Color.Black; // Cor padrão
            }
        }

        private async void BtnTranslateWithGoogle_Click(object sender, EventArgs e)
        {
            string originalText = txtOriginalText.Text;

            if (string.IsNullOrWhiteSpace(originalText))
            {
                MessageBox.Show("Por favor, insira um texto no campo 'Texto Original'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Divide o texto original em linhas
                string[] lines = originalText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                // Traduz cada linha individualmente e mantém a formatação
                List<string> translatedLines = new List<string>();
                foreach (string line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string translatedLine = await TranslateWithGoogleAsync(line, "pt");
                        translatedLines.Add(translatedLine);
                    }
                    else
                    {
                        translatedLines.Add(string.Empty); // Mantém linhas vazias
                    }
                }

                // Junta as linhas traduzidas e exibe no textBox1
                textBox1.Text = string.Join(Environment.NewLine, translatedLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao traduzir o texto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private async Task<string> TranslateWithGoogleAsync(string text, string targetLang)
        {
            try
            {
                string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl={targetLang}&dt=t&q={Uri.EscapeDataString(text)}";
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(jsonResponse);
                    return result[0][0][0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao acessar o Google Translate: {ex.Message}");
            }
        }

        private string caminhoPastaSelecionada; // Variável para armazenar o caminho da pasta selecionada

        private void BtnSelectFolder_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione a pasta contendo os scripts de texto originais";
                openFileDialog.Filter = "Pasta|*.folder"; // Filtro fictício para simular seleção de pastas
                openFileDialog.CheckFileExists = false; // Permite selecionar pastas
                openFileDialog.FileName = "Selecione esta pasta"; // Texto exibido no campo de nome do arquivo

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = Path.GetDirectoryName(openFileDialog.FileName);
                    caminhoPastaSelecionada = selectedPath;

                    // Obter todos os arquivos com as extensões especificadas
                    string[] files = Directory.GetFiles(caminhoPastaSelecionada, "*.*", SearchOption.TopDirectoryOnly)
                                               .Where(file => file.EndsWith(".asm", StringComparison.OrdinalIgnoreCase) ||
                                                              file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) ||
                                                              file.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase) ||
                                                              file.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                                               .ToArray();

                    // Limpar o ComboBox e adicionar os arquivos encontrados
                    comboBoxScripts.Items.Clear();
                    foreach (string file in files)
                    {
                        comboBoxScripts.Items.Add(Path.GetFileName(file));
                    }

                    // Exibir uma mensagem se nenhum arquivo for encontrado
                    if (files.Length == 0)
                    {
                        MessageBox.Show("Nenhum arquivo .asm, .txt, .yaml ou .xml foi encontrado na pasta selecionada.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void comboBoxScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(caminhoPastaSelecionada))
            {
                MessageBox.Show("Nenhuma pasta foi selecionada. Por favor, selecione uma pasta primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtém o nome do arquivo selecionado no comboBoxScripts
            string selectedFile = comboBoxScripts.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedFile))
            {
                MessageBox.Show("Nenhum arquivo foi selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Constrói o caminho completo do arquivo
            string fullPath = Path.Combine(caminhoPastaSelecionada, selectedFile);

            // Verifica se o arquivo existe antes de tentar carregá-lo
            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"O arquivo '{selectedFile}' não foi encontrado no caminho '{caminhoPastaSelecionada}'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Carrega o script no listBox2
            CarregarScript(fullPath);
        }




        private void CarregarScript(string caminho)
        {
            try
            {
                caminhoScriptOriginal = caminho; // Atualiza o caminho do script original
                string[] lines = File.ReadAllLines(caminho);

                // Limpa o dicionário antes de preenchê-lo novamente
                novoScriptMap.Clear();
                string currentLabel = null;

                foreach (string line in lines)
                {
                    if (Regex.IsMatch(line.Trim(), @"^[a-zA-Z_]+\d+:$"))
                    {
                        currentLabel = line.TrimEnd(':').Trim();
                        if (!novoScriptMap.ContainsKey(currentLabel))
                        {
                            novoScriptMap[currentLabel] = string.Empty;
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(line) && currentLabel != null)
                    {
                        novoScriptMap[currentLabel] += line + Environment.NewLine;
                    }
                }

                listBox2.Items.Clear();
                foreach (var label in novoScriptMap.Keys)
                {
                    listBox2.Items.Add(label + ":");
                }

                MessageBox.Show("Script carregado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o script: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnSelectTranslatedFolder_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione a pasta contendo os scripts traduzidos";
                openFileDialog.Filter = "Pasta|*.folder";
                openFileDialog.CheckFileExists = false;
                openFileDialog.FileName = "Selecione esta pasta";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = Path.GetDirectoryName(openFileDialog.FileName);
                    caminhoPastaTraduzidos = selectedPath;

                    // Obter todos os arquivos com as extensões especificadas
                    string[] files = Directory.GetFiles(caminhoPastaTraduzidos, "*.*", SearchOption.TopDirectoryOnly)
                                               .Where(file => file.EndsWith(".asm", StringComparison.OrdinalIgnoreCase) ||
                                                              file.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) ||
                                                              file.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase) ||
                                                              file.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                                               .ToArray();

                    // Limpar o ComboBox e adicionar os arquivos encontrados
                    comboBoxTranslatedScripts.Items.Clear();
                    foreach (string file in files)
                    {
                        comboBoxTranslatedScripts.Items.Add(Path.GetFileName(file));
                    }

                    // Exibir uma mensagem se nenhum arquivo for encontrado
                    if (files.Length == 0)
                    {
                        MessageBox.Show("Nenhum arquivo .asm, .txt, .yaml ou .xml foi encontrado na pasta selecionada.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void comboBoxTranslatedScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(caminhoPastaTraduzidos))
            {
                MessageBox.Show("Nenhuma pasta foi selecionada. Por favor, selecione uma pasta primeiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtém o nome do arquivo selecionado no comboBoxTranslatedScripts
            string selectedFile = comboBoxTranslatedScripts.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedFile))
            {
                MessageBox.Show("Nenhum arquivo foi selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Constrói o caminho completo do arquivo
            string fullPath = Path.Combine(caminhoPastaTraduzidos, selectedFile);

            // Verifica se o arquivo existe antes de tentar carregá-lo
            if (!File.Exists(fullPath))
            {
                MessageBox.Show($"O arquivo '{selectedFile}' não foi encontrado no caminho '{caminhoPastaTraduzidos}'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Carrega o script traduzido na listBox1
            CarregarScriptTraduzido(fullPath);
        }


        private string caminhoPastaTraduzidos; // Caminho da pasta dos scripts traduzidos


        private void BtnLoadFolder_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Selecione uma pasta para carregar arquivos .asm";
                openFileDialog.Filter = "Pasta|*.folder";
                openFileDialog.CheckFileExists = false;
                openFileDialog.FileName = "Selecione esta pasta";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = Path.GetDirectoryName(openFileDialog.FileName);
                    treeViewFiles.Nodes.Clear();
                    LoadFolderIntoTreeView(selectedPath, treeViewFiles.Nodes);
                }
            }
        }

        private void LoadFolderIntoTreeView(string folderPath, TreeNodeCollection nodes)
        {
            try
            {
                // Adiciona os arquivos .asm na pasta atual
                string[] asmFiles = Directory.GetFiles(folderPath, "*.asm");
                foreach (string file in asmFiles)
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file))
                    {
                        Tag = file // Armazena o caminho completo no Tag
                    };
                    nodes.Add(fileNode);
                }

                // Adiciona as subpastas
                string[] subFolders = Directory.GetDirectories(folderPath);
                foreach (string folder in subFolders)
                {
                    TreeNode folderNode = new TreeNode(Path.GetFileName(folder));
                    nodes.Add(folderNode);
                    LoadFolderIntoTreeView(folder, folderNode.Nodes); // Recursivamente adiciona subpastas e arquivos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar a pasta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TreeViewFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is string filePath && File.Exists(filePath))
            {
                try
                {
                    // Lê o conteúdo do arquivo
                    string fileContent = File.ReadAllText(filePath);

                    // Define o conteúdo no scintillaEditor
                    scintillaEditor.Text = fileContent;

                    // Opcional: Atualiza o título do formulário com o nome do arquivo
                    this.Text = $"RTX Translation Tool - {Path.GetFileName(filePath)}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void scintillaEditor_Click(object sender, EventArgs e)
        {

        }

        private void ConfigureScintillaColors()
        {
            // Fundo e texto padrão
            scintillaEditor.Styles[ScintillaNET.Style.Default].BackColor = Color.FromArgb(30, 30, 30); // Fundo escuro
            scintillaEditor.Styles[ScintillaNET.Style.Default].ForeColor = Color.FromArgb(212, 212, 212); // Texto claro
            scintillaEditor.StyleClearAll();

            // Comentários
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.Comment].ForeColor = Color.FromArgb(87, 166, 74); // Verde escuro
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.CommentLine].ForeColor = Color.FromArgb(165, 190, 213);

            // Strings
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.String].ForeColor = Color.FromArgb(134, 198, 145); // Laranja

            // Palavras-chave (instruções do 65816, como lda, sta, etc.)
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.Word].ForeColor = Color.FromArgb(86, 120, 214); // Azul claro
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.Word].Bold = true;

            // Números
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.Number].ForeColor = Color.FromArgb(226, 236, 240); // Verde claro

            // Operadores
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.Operator].ForeColor = Color.FromArgb(255, 200, 20); // Branco

            // Labels (como "extra_chars:")
            scintillaEditor.Styles[ScintillaNET.Style.Cpp.Identifier].ForeColor = Color.FromArgb(226, 236, 240); // Amarelo claro

            // Fundo da linha atual
            scintillaEditor.CaretLineBackColor = Color.FromArgb(45, 45, 45); // Fundo da linha atual
            scintillaEditor.CaretLineVisible = true;

            // Configurar palavras-chave específicas do 65816
            scintillaEditor.SetKeywords(0, "lda sta and ora eor adc sbc cmp cpx cpy inc dec asl lsr rol ror brk nop sei cli clc sec pha pla phx plx phy ply rep sep jmp jsr rts rti bcc bcs beq bmi bne bpl bra brl bvc bvs");
        }



        private void ConfigureTreeViewColors()
        {
            // Fundo e texto padrão
            treeViewFiles.BackColor = Color.FromArgb(30, 30, 30); // Fundo escuro
            treeViewFiles.ForeColor = Color.FromArgb(212, 212, 212); // Texto claro

            // Seleção
            treeViewFiles.LineColor = Color.FromArgb(45, 45, 45); // Cor das linhas
            treeViewFiles.HideSelection = false; // Permite destacar o item selecionado mesmo sem foco
        }

        private void BtnSalvarAsm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(caminhoScriptOriginal))
                {
                    // Salva o conteúdo do scintillaEditor no arquivo original
                    File.WriteAllText(caminhoScriptOriginal, scintillaEditor.Text);
                    MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo está sendo editado no momento. Use 'Salvar Como' para definir um caminho.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnSalvarAsmComo_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Arquivos ASM (*.asm)|*.asm|Todos os Arquivos (*.*)|*.*",
                    Title = "Salvar Arquivo Como"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Atualiza o caminho do arquivo e salva o conteúdo
                    caminhoScriptOriginal = saveFileDialog.FileName;
                    File.WriteAllText(caminhoScriptOriginal, scintillaEditor.Text);
                    MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }













    }



















}
