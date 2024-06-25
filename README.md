# 📃 Sistema de Folha de Pagamento

## 👀 Visão Geral

Este projeto é um sistema de folha de pagamento desenvolvido em C#. Ele permite que os administradores gerenciem informações dos funcionários, calculando salários líquidos, horas extras e gerando relatórios de pagamento. O sistema foi projetado para atender tanto administradores quanto funcionários, proporcionando uma interface amigável e funcional.

## 📑 Funcionalidades

### Administrador
- Login de usuário administrador.
- Manter informações dos funcionários (endereços, telefones, etc.).
- Calcular salário líquido dos funcionários.
- Gerar relatórios de pagamento.

### Funcionário
- Login de usuário funcionário.
- Visualizar informações pessoais e de pagamento.
- Calcular horas extras.

## 📊 Diagramas

### Diagrama de Caso de Uso
O diagrama de caso de uso ilustra as interações entre os administradores e funcionários com o sistema, destacando as principais funcionalidades oferecidas.

![Diagrama de Caso de Uso](imagens/diagrama-caso-de-uso.jpg)

### Diagrama de Classe
O diagrama de classe detalha a estrutura do sistema, mostrando as classes principais, seus atributos e métodos, além das relações entre elas.

![Diagrama de Classe](imagens/diagrama-de-classe.jpg)

## 👨‍💻 Tecnologias Utilizadas

- C#
- Windows Forms
- Entity Framework (ou qualquer outro ORM, se aplicável)
- Excel (ou outro banco de dados, alterando a chave de conexão)

## 📚 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/CaioGonzalezDeJeus/projeto-folha-de-pagamento.git

2. Abra o projeto no Visual Studio.

3. Restaure os pacotes NuGet.

4. Execute o projeto.