# Injeção Dependência


*Não é um padrão (Design Pattern);
*Técnica que implementa o IoC:
  *Inversão de Controle
  *DIP
*Ajuda no baixo acoplamento;
*Provê uma melhor divisão de responsabilçidades.

# I. Baixo Acoplamento

*Tem que funcionar de forma independente;
*Fácil de entender;
*Fácil de manutenção;
*Se precisar joga fora e cria outro é facil.

# II. Inversão de Controle

*Externaliza as responsabilidaddes (Delega);
*Cria uma dependência externa.

# III. Porque Abstrair?

*Facilita a mudanças (ex: troca de um banco de dados)
*Teste de Unidade (não pode depender de banco, rede ou qualuqer outra coisa externa);
*Se você depende da abstração, a implementação não importa.

# IV. Princípio da Inversão de Dependência (DIP)

*Principio da inversão de dependência;
*Depende de abstração e não de implementações

# V. AddScoped, AddTransient, AddSingleton

Há quatro modos de vida para um serviço que está sendo injetado:
1. Singleton : Um objeto do serviço é criado e fornecido para todas as requisições. Assim, todas as requisições obtém o mesmo objeto;
2. Escoped : Um objeto do serviço é criado para cada requisição. Dessa forma, cada requisição obtém uma nova instância do serviço;
3. Transient : Um objeto do serviço é criado toda a vez que um objeto for requisitado (Ex: 200).

P.S.: Deixarei um repositório com um exemplo prático.
