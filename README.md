## Teste da Estapar em Aspnet MVC core 3.0
*Neste repositório constam todos os fontes gerados para realizar o teste da Estapar*  

> Os teste foram feitos com IISExpres e o banco de dados escolhido foi SqlServer utilizando EF core com provider para InMemmoryDatabase

### Modelagem
![Modelagem](https://github.com/ricardovicentini/teste-estapar/blob/master/imagens/Diagram%20Estapar.png)

Semanticamente com essa modelagem podemos dizer que uma instância de manobrista manobra uma instância de caro.  

E com isso então foram criados Models, Views e Controlers para geração do CRUD de acordo com o solicitado.

## Tecnicas Aplicadas
* Models ricas: Escolhi trabalhar com models ricas para emular um design baseado no DDD. *Como é apenas um teste entendi que poderia ter a entidade e a model como um objeto unico* E atendeu bem!  
* Views 100% RAZOR com validações utilizando o Framework: *FluentValidation* https://fluentvalidation.net/, que excelentemente transpila as validações para o javiscript sem sujar as models e ainda é possivel utilizar a mesma validação nas camadas Server
