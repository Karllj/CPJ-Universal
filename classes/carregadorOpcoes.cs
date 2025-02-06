using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CPJ_Universal.classes
{
    namespace CPJ_Universal.classes
    {
        internal class CarregadorOpcoes
        {
            public List<string> ListaArquivosCPJ3C { get; private set; } = new List<string>();
            public List<string> ListaArquivosARQ3C { get; private set; } = new List<string>();
            public List<string> ListaAdmins { get; private set; } = new List<string>();

            public void FiltrarVersoesCPJ3C(ComboBox comboBox, string filtro)
            {
                var itensFiltrados = ListaArquivosCPJ3C
                    .Where(item => item.ToLower().Contains(filtro.ToLower()))
                    .ToList();

                AtualizarComboBox(comboBox, itensFiltrados);
            }

            public void FiltrarARQ3C(ComboBox comboBox, string filtro)
            {
                var itensFiltrados = ListaArquivosARQ3C
                    .Where(item => item.ToLower().Contains(filtro.ToLower()))
                    .ToList();

                AtualizarComboBox(comboBox, itensFiltrados);
            }

            public void FiltrarAdmins(ComboBox comboBox, string filtro)
            {
                var itensFiltrados = ListaAdmins
                    .Where(item => item.ToLower().Contains(filtro.ToLower()))
                    .ToList();

                AtualizarComboBox(comboBox, itensFiltrados);
            }

            private void AtualizarComboBox(ComboBox comboBox, List<string> itens)
            {
                comboBox.Items.Clear();
                comboBox.Items.Add(""); // Adiciona a opção em branco
                foreach (var item in itens)
                {
                    comboBox.Items.Add(item);
                }

                // Mantém o texto digitado e a lista aberta
                comboBox.DroppedDown = true;
                Cursor.Current = Cursors.Default;
                if (!string.IsNullOrEmpty(comboBox.Text))
                {
                    comboBox.SelectionStart = comboBox.Text.Length;
                    comboBox.SelectionLength = 0;
                }
            }

            public void LoadBancoDeDadosOptions(ComboBox selectBoxBanco)
            {
                string path = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Help Desk - Help Desk\\CPJ-Universal\\bancodedados\\versao";

                if (Directory.Exists(path))
                {
                    selectBoxBanco.Items.Clear();
                    selectBoxBanco.Items.Add(""); // Adiciona a opção em branco
                    foreach (var file in Directory.GetFiles(path))
                    {
                        selectBoxBanco.Items.Add(Path.GetFileName(file));
                    }
                }
            }

            public void LoadARQ3COptions(ComboBox selectBoxARQ3C)
            {
                string path = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Produção\\ARQ-3C";

                selectBoxARQ3C.Items.Clear();
                ListaArquivosARQ3C.Clear();
                selectBoxARQ3C.Items.Add(""); // Adiciona a opção em branco

                if (Directory.Exists(path))
                {
                    ListaArquivosARQ3C = Directory.GetFiles(path, "*.zip", SearchOption.AllDirectories)
                        .Where(file => Path.GetFileName(file).StartsWith("ARQ"))
                        .Select(Path.GetFileName)
                        .ToList();

                    foreach (var fileName in ListaArquivosARQ3C)
                    {
                        selectBoxARQ3C.Items.Add(fileName);
                    }
                }

                selectBoxARQ3C.SelectedIndex = 0; // Seleciona a opção em branco
            }

            public void LoadAdminOptions(ComboBox cbAdmin)
            {
                string repoPathBase = $"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Produção\\CPJ-Admin";

                if (Directory.Exists(repoPathBase))
                {
                    var arquivosAdmin = Directory.GetFiles(repoPathBase, "*.exe", SearchOption.AllDirectories);
                    ListaAdmins = arquivosAdmin.Select(Path.GetFileName).Distinct().ToList();

                    cbAdmin.Items.Clear();
                    cbAdmin.Items.Add(""); // Adiciona a opção em branco
                    cbAdmin.Items.AddRange(ListaAdmins.ToArray());
                }
            }

            public void LoadModelosCPJOptions(ComboBox cbModeloCPJ)
            {
                string path = @"C:\PREAMBULO\CPJ3C";

                if (Directory.Exists(path))
                {
                    cbModeloCPJ.Items.Clear();
                    cbModeloCPJ.Items.Add(""); // Adiciona a opção em branco

                    var directories = Directory.GetDirectories(path);

                    foreach (var dir in directories)
                    {
                        cbModeloCPJ.Items.Add(Path.GetFileName(dir));
                    }

                    cbModeloCPJ.SelectedIndex = 0; // Define a primeira opção como selecionada
                }
            }

            //Vai atualizar a lista das verões de acordo com o modelo selecionado
            public void AtualizarVersoesCPJ3C(ComboBox selectBoxCPJ3C, ComboBox selectBoxVersaoCPJ3C)
            {
                string selecionado = selectBoxCPJ3C.SelectedItem?.ToString();

                selectBoxVersaoCPJ3C.Items.Clear();
                ListaArquivosCPJ3C.Clear();
                selectBoxVersaoCPJ3C.Items.Add("");

                if (!string.IsNullOrEmpty(selecionado))
                {
                    string path = Path.Combine($"{Configuracoes.EnderecoGlobal}\\Preambulo - Geral - Produção", selecionado.ToLower());

                    if (Directory.Exists(path))
                    {
                        ListaArquivosCPJ3C = Directory.GetFiles(path, "*.zip", SearchOption.AllDirectories)
                            .Select(Path.GetFileName)
                            .ToList();

                        foreach (var file in ListaArquivosCPJ3C)
                        {
                            selectBoxVersaoCPJ3C.Items.Add(file);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma versão encontrada para a opção selecionada.");
                    }
                }

                selectBoxVersaoCPJ3C.SelectedIndex = 0;
            }

            public void AtualizarModelosCPJ(ComboBox cbModeloCPJ, ComboBox cbVersaoInstalada)
            {
                string modeloSelecionado = cbModeloCPJ.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(modeloSelecionado))
                {
                    string path = Path.Combine(@"C:\PREAMBULO\CPJ3C", modeloSelecionado);

                    if (Directory.Exists(path))
                    {
                        cbVersaoInstalada.Items.Clear();
                        cbVersaoInstalada.Items.Add(""); // Adiciona a opção em branco

                        var directories = Directory.GetDirectories(path);

                        foreach (var dir in directories)
                        {
                            cbVersaoInstalada.Items.Add(Path.GetFileName(dir));
                        }

                        cbVersaoInstalada.SelectedIndex = 0; // Define a primeira opção como selecionada
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma versão instalada encontrada para o modelo selecionado.");
                    }
                }
            }

            public string LocalizarArquivoOuPastaEmSubpastas(string diretorioBase, string nomeParcial)
            {
                if (string.IsNullOrEmpty(diretorioBase))
                    throw new ArgumentException("O diretório base não pode ser nulo ou vazio.", nameof(diretorioBase));

                if (string.IsNullOrEmpty(nomeParcial))
                    throw new ArgumentException("O nome parcial do arquivo não pode ser nulo ou vazio.", nameof(nomeParcial));

                var arquivos = Directory.GetFiles(diretorioBase, "*.*", SearchOption.AllDirectories)
                    .Where(f => Path.GetFileName(f).IndexOf(nomeParcial, StringComparison.OrdinalIgnoreCase) >= 0);

                return arquivos.FirstOrDefault();
            }

            public void LoadARQ3CDirectories(ComboBox comboBoxARQ3C)
            {
                string path = @"C:\PREAMBULO\ARQ3C";  // Caminho para o diretório ARQ3C

                if (Directory.Exists(path))
                {
                    comboBoxARQ3C.Items.Clear();
                    comboBoxARQ3C.Items.Add(""); // Adiciona a opção em branco

                    var directories = Directory.GetDirectories(path)
                                               .Select(Path.GetFileName)
                                               .ToList();

                    foreach (var dir in directories)
                    {
                        comboBoxARQ3C.Items.Add(dir);  // Adiciona os diretórios (ARQ3C) encontrados
                    }

                    comboBoxARQ3C.SelectedIndex = 0;  // Define a primeira opção como selecionada
                }
                else
                {
                    MessageBox.Show("O diretório ARQ3C não foi encontrado.");
                }
            }

        }
    }
}
