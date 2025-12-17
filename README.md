# Livraria - Projeto WPF com SQL Server

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12.0-239120?style=flat&logo=csharp)](https://learn.microsoft.com/dotnet/csharp/)
[![WPF](https://img.shields.io/badge/WPF-Windows_Desktop-0078D4?style=flat&logo=windows)](https://learn.microsoft.com/dotnet/desktop/wpf/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

![Demonstração da aplicação](Library/Resources/Library.gif)

## Funcionalidades

  - **Pesquisa de livros por texto** - Filtra livros a partir de um título inserido
  - **Rolagem infinita** - Carrega mais livros automaticamente ao rolar
  - **Resposividade** - É possível visualizar a interface de forma adaptável
  - **Filtro case-insensitive** - A busca é feita ignorando letras maiúsculas/minúsculas

## Tecnologias utilizadas

  - **.NET 9.0**
  - **C# 12**
  - **WPF (Windows Presentaion Foundation)**
  - **MVVM Pattern**
  - **XAML**
  - **ObservableCollection** (binding e notificação de mudanças)
  - **INotifiPropertyChanged** (atualização automática da UI)

## Estrutura do Projeto

```text
LibraryApp/
|
├── Models/
│ └── Books.cs # Modelo de dados do livro
|
├── ViewModels/
│ └── BooksViewModel.cs # Lógica de negócio e dados
|
├── Views/
│ ├── BooksPainel.xaml # Painel principal de livros
│ ├── MainMenu.xaml # Menu principal
│ ├── SearchOrder.xaml # Barra de busca
│ ├── SideBar.xaml # Barra lateral
│ └── WindowsButtons.xaml # Botões da janela
|
├── Services/
│ └── BookService.cs # Serviço de leitura de CSV
|
├── Data/
│ └── books_cleaned.csv # Base de dados de livros
|
└── Resources/
└── (ícones e assets)
```

## Dados utilizados

<p>Para dados, gerei </p>
