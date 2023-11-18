//No exemplo abaixo houve perda da precisão pelo fato da variavel inteira não suportar as casas decimais
double numDouble = 3.14;
int numInt = (int)numDouble; 
Console.WriteLine(numInt);

/*É importante notar que sesempre que a parte fracionária da variável double não puder ser representada como um número inteiro, 
a conversão resultará em perda de dados, pois a parte decimal será truncada.*/