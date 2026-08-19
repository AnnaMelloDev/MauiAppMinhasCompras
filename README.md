# 🛒 Aplicativo Minhas Compras — .NET MAUI & SQLite

Repositório contínuo desenvolvido para as atividades práticas da disciplina de **Desenvolvimento de Sistemas III** (3º Semestre - Curso Técnico Etec).

---

## 📚 Divisão e Evolução das Agendas

### 📌 Agenda 1: Modelagem de Dados (Models)
* **Objetivo:** Estruturação da base do projeto e criação da classe principal de domínio.
* **Arquivos:** `Modelos/Produto.cs`
* **Implementação:** Definição da estrutura do produto com as propriedades de identificação (`Id`), descrição (`Descrição`), quantidade (`Quantidade`) e valor (`Preço`), mapeando os atributos primários para o SQLite.

### 📌 Agenda 2: Camada de Persistência (Helpers)
* **Objetivo:** Construção da classe de manipulação direta da base de dados local.
* **Arquivos:** `Ajudantes/SQLiteDatabaseHelper.cs`
* **Implementação:** Criação da classe auxiliar responsável por abrir a conexão com a biblioteca `SQLite-net-pcl` e gerenciar as operações assíncronas de inserção e consulta no banco.

### 📌 Agenda 3: Conexão e Interface Gráfica (Etapa Atual)
* **Objetivo:** Configuração da rota inicial do banco de dados e construção da View de cadastro.
* **Arquivos:** `App.xaml.cs`, `Vistas/NovoProduto.xaml` e `Vistas/NovoProduto.xaml.cs`
* **Implementação:** Definido o caminho do arquivo de persistência (`banco_sqlite_compras.db3`) no ciclo de vida global da aplicação e desenvolvida a interface gráfica para captação dos dados e efetivação do salvamento do primeiro registro.

---

## 🛠️ Tecnologias Utilizadas
* C# / XAML
* .NET MAUI
* SQLite-net-pcl
