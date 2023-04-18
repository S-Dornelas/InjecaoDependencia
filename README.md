# Injeção Dependência


1.Não é um padrão (Design Pattern);
2.Técnica que implementa o IoC:
  *Inversão de Controle
  *DIP
3.Ajuda no baixo acoplamento;
4.Provê uma melhor divisão de responsabilçidades.

# I. Baixo Acoplamento

1.Tem que funcionar de forma independente;
2.Fácil de entender;
3.Fácil de manutenção;
4.Se precisar joga fora e cria outro é facil.

# II. Inversão de Controle

1.Externaliza as responsabilidaddes (Delega);
2.Cria uma dependência externa.

# III. Porque Abstrair?

1.Facilita a mudanças (ex: troca de um banco de dados)
2.Teste de Unidade (não pode depender de banco, rede ou qualuqer outra coisa externa);
3.Se você depende da abstração, a implementação não importa.

# IV. Princípio da Inversão de Dependência (DIP)

1.Principio da inversão de dependência;
2.Depende de abstração e não de implementações

# V. AddScoped, AddTransient, AddSingleton

Há três modos de vida para um serviço que está sendo injetado:
1. Singleton : Um objeto do serviço é criado e fornecido para todas as requisições. Assim, todas as requisições obtém o mesmo objeto;
2. Escoped : Um objeto do serviço é criado para cada requisição. Dessa forma, cada requisição obtém uma nova instância do serviço;
3. Transient : Um objeto do serviço é criado toda a vez que um objeto for requisitado (Ex: 200).

P.S.: Deixarei um repositório com um exemplo prático.
