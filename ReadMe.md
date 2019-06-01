# :wine_glass: Goblins Dev's Line WIKI


**Objetivo geral**

Desenvolver uma aplicação na linguagem C#, capaz de gerenciar uma pequena empresa.
A aplicação terá a finalidade de realizar venda de no mínimo 15 produtos, divididos
obrigatoriamente em 3 (três) categorias.

***

**Objetivo específico**
A aplicação deverá ser capaz de realizar as seguintes ações:

* Gestão de Usuários (funcionários)
* Gestão de Clientes
* Gestão Financeira
* Gestão de produtos

Partes a serem entregues
* Apresentação em ppt
* Diagrama de Classe
* Mapa do código
* Manual de instruções
* Parte escrita (regras da ABNT)
* Código completo

***

**Módulos da aplicação**
Os módulos listados a seguir serão de caráter obrigatório, contudo o grupo poderá adicionado novos
módulos ou funcionalidades extras a seu critério.

* Tela de abertura da aplicação (logomarca)
* Tela de carregamento do sistema (utilizar tabela ASCII e Random)
* Tela de login (3 tentativas permitidas)
  * Recuperação de senha (funcionário)
  * Usuário Mestre (root)
* Tela de Ajuda (F1)

***

**Módulo de Gestão de usuários (funcionários)**
* Cadastrar
* Editar
* Excluir
* Consultas
  * Por nome
  * Por CPF
  * Listar todos os funcionários

O sistema deverá realizar cadastro dos funcionários com os seguintes dados:
 * CPF
 * Nome do Funcionário
 * Cargo
Obs I.: Será obrigatório validar o CPF, caso o CPF não seja válido, não será permitido o cadastro.
Obs II.: Para facilitar o processo, o sistema já deverá iniciar com 3 cadastros.

***
**Gestão de Clientes**
 * Cadastrar
 * Editar
 * Excluir
 * Consultas
   * Por nome
   * Por CPF
   * Listar todos os clientes

O sistema deverá realizar cadastro dos clientes com os seguintes dados:
 * CPF
 * Nome do cliente
 * Telefone
 * Cidade
 * E-mail
 
Obs I.: Será obrigatório validar o CPF, caso o CPF não seja válido, não será permitido o cadastro.
Obs II.: Para facilitar o processo, o sistema já deverá iniciar com 3 cadastros.
Obs III.: O e-mail deverá ser gravado apenas em caixa baixa.

***
**Gestão Financeira**
* Relatório financeiro de vendas mensal
* Relatório financeiro de vendas do dia
* Relatório financeiro de vendas por cliente

***
**Gestão de Produtos**
* Cadastrar
* Editar
* Excluir
* Consultas
  * Por Código
  * Por nome do produto
  * Listar todos os produtos

O sistema deverá realizar cadastro dos produtos com os seguintes dados:
* Código
* Nome
* Descrição
* Quantidade em estoque
* Preço

Obs I: A quantidade em estoque não poderá ser inferior a 0.
Obs II: O preço do produto não poderá ser inferior ou igual a 0.

*Tela de finalização do sistema*

***
**Operação de vendas**
* Para realizar as vendas, o sistema solicitara o CPF do cliente e exibirá seus dados para
iniciar a venda, caso o CPF, já esteja cadastrado, caso contrário, perguntar se deseja
cadastrar novo cliente.
* O sistema exibira as opções de produtos, com seus respectivos dados.
* Para realizar venda deverá ser digitado o código e a quantidade do produto. Um cliente
poderá comprar mais de um produto, na mesma venda.
* Após finalizar a venda para o referido cliente, o sistema apresentará o resumo da compra.
O sistema realizará o cálculo do valor a ser pago pelo cliente e seu respectivo troco.
* O sistema poderá realizar vendas para mais de um cliente
