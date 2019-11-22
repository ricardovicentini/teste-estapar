## Teste da Estapar em Aspnet MVC core 3.0
*Neste repositório constam todos os fontes gerados para realizar o teste da Estapar*  

> Os testes foram feitos com IISExpres e o banco de dados escolhido foi SqlServer utilizando EF core com provider para InMemmoryDatabase

### Modelagem
![Modelagem](https://github.com/ricardovicentini/teste-estapar/blob/master/imagens/Diagram%20Estapar.png)

Semanticamente com essa modelagem podemos dizer que uma instância de manobrista manobra uma instância de caro.  

E com isso então foram criados Models, Views e Controlers para geração do CRUD de acordo com o solicitado.

## Tecnicas Aplicadas
* Models ricas: Escolhi trabalhar com models ricas para emular um design baseado no DDD. *Como é apenas um teste entendi que poderia ter a entidade e a model como um objeto unico* E atendeu bem!  
* Views 100% RAZOR com validações utilizando o Framework: *FluentValidation* https://fluentvalidation.net/, que excelentemente transpila as validações para o javiscript sem sujar as models e ainda é possivel utilizar a mesma validação nas camadas Server. E ainda de bonos as validações são escritas de forma declarativa (Linq Like), o que garante rapidez na criação das validações e facilidade para entendê-las
* CLEAN CODE / SOLID: O código foi escrito aplicando-se os principios de: 
  > Responsabilidade única dos métodos
  > Pincípio de Aberto / Fechado: As models foram escritas de forma que não podem ser alteradas de fora, para garantir este principio 
  > Princípio de Substituição de Liskov: (não foi aplicado pois não utilizei herança) 
  > Interface segragation: (não apliquei 100% mas temos duas interfaces que facilitaram bem o desnevolvimento) *ICRUD* e *IModel*
  > Dependencia por injeçao: Foi utilizado o injetor padrão do netcore que é ótimo e muito fácil de usar
## Tetes
* Não foram feitos testes atomatizados devido a simplicidade da tarefa e a urgência no tempo, mas o código está bem desacoplado e fácil de testar


## Agradecimento
Obrigado pela oportunidade de mostrar meu trabalho!

  


