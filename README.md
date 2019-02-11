# Banco

O sistema do banco tem duas partes principais: Admin e Caixa eletrônico

Primeiro será feita a parte de Administração.

## Admin
### Regras de negócio
Projeto de administração. Nele temos o gerenciamento de Clientes e Contas (adicionar, alterar, remover ou consultar).
O sistema abre com as opções: 1-Clientes, 2-Contas, 3-Operações e 0-Sair.
Se selecionar a opcao 'Clientes' aparece o menu de gerenciamento de clientes (adicionar, remover, etc).
Se selecionar a opcao 'Contas' deve perguntar qual o CPF do cliente, depois mostrar menu de gerenciamento.
Se selecionar a opcao 'Operaçõeos' deve perguntar qual o Numero da conta, depois mostrar o menu.
O menu de operações deve ter as opções: 1-Depósito, 2-Saque. E em seguida perguntar o valor.

- Clientes
  - CPF
  - Nome
  - Data de nascimento
- Contas
  - Numero (criacao automatica / não repetido)
  - Saldo

- Regras
  - Não é possivel adicionar 2 clientes com o mesmo CPF
  - O cliente deve 18 anos ou mais
  - Toda conta é aberta com 100 reais de crédito
  - O saldo nunca pode ser negativo

## Especificações técnicas
Funcionalidades não relacionadas ao principal do negócio devem ser colocadas em suas próprias Libs para melhorar a organização.
impressão dos menus e operações com array se encaixam nessa categoria.

**Importante:** Usar o estilo de código padrão do C# (ver https://github.com/raywenderlich/c-sharp-style-guide, não é o oficial mas é igual, e mais fácil de ler)

**Importante 2:** Nomes bonitos para as variáveis

Sugiro a criação de uma nova Solution em outro Repositório só com esses projetos.

### MenuLib
Cuida da impressão dos menus, deve ter os métodos:
- ```void PrintMessage(string) //recebe um texto```
- ```void PrintOptions(string, string[]) //recebe um texto explicativo e a lista das opções```
- ```int ReadOption(string opcional) //recebe um texto para mostrar antes de ler a opcao. Se nao passar nada escrever: "Digite o número da opção". Deve validar o número da opçao se possível```
- ```decimal ReadMoneyValue(string opcional) //recebe um texto para mostrar antes de ler o número. Se nao passar nada escrever: "Digite o valor:". Deve verificar se é um numero válido.```
- ```string ReadStringValue(string opcional) //recebe um texto para mostrar antes de ler o valor. Se nao passar nada escrever: "Digite o valor:"```
Os métodos não precisam ser exaaatamente assim.

### ArrayLib
Cuida das operações com array, deve ter os métodos:
- ```void Sort(string[]) //ordena o array```
- ```int Search(string[], string) //retorna o indice do valor ou -1```
- ```int BinarySearch(string[], string) //retorna o indice do valor ou -1 (usar para arrays ordenados)```
- ```void Trim(string[]) //remove vazios (null ou "") do array```
Os métodos não precisam ser exaaatamente assim. Pode ser que seja necessário adicionar mais métodos durante o desenvolvimento.