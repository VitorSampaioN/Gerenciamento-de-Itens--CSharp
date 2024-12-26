# Gerenciador de Tarefas

## Descrição
Este é um programa simples em C# para gerenciar tarefas, permitindo ao usuário:
- Adicionar novas tarefas.
- Atualizar o status de tarefas existentes.
- Visualizar a lista de tarefas com seus respectivos status.

O programa é executado no terminal e utiliza uma interface de menu interativo.

---

## Funcionalidades
1. **Adicionar Tarefa**  
   - Permite ao usuário cadastrar uma nova tarefa.
   - O status inicial da tarefa é configurado automaticamente como "A Fazer".

2. **Atualizar Status de uma Tarefa**  
   - Altere o status de uma tarefa para:
     - A Fazer
     - Em Progresso
     - Concluída

3. **Exibir Tarefas**  
   - Mostra a lista completa de tarefas com os respectivos status.

4. **Sair do Programa**  
   - Finaliza a execução do programa.

---

## Estrutura do Código
- **Enums:**  
  - `Opcoes`: Representa as opções do menu.  
  - `Status`: Define os status disponíveis para uma tarefa.  

- **Métodos principais:**  
  - `Main`: Controla o fluxo do programa.
  - `selecionarOpcao`: Exibe o menu e captura a escolha do usuário.
  - `adicionarTarefa`: Adiciona uma nova tarefa à lista.
  - `exibirTarefas`: Exibe todas as tarefas registradas e seus status.
  - `atualizarStatus`: Permite ao usuário atualizar o status de uma tarefa.
  - `mensagemErro`: Exibe mensagens de erro para entradas inválidas.

---

## Como Executar
1. Certifique-se de ter o .NET SDK instalado no seu sistema.  
   [Download do .NET SDK](https://dotnet.microsoft.com/download)

2. Clone ou baixe o repositório:
   ```bash
   git clone https://github.com/seu_usuario/nome_do_repositorio.git
   cd nome_do_repositorio
