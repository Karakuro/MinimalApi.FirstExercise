using MinimalApi.FirstExercise;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
/*
 Modificare la GET affinché riceva
 tre parametri di tipo STRING in ingresso
 e restituisca la concatenazione risultante
 ES: Input => https://localhost:8800?a=CIAO&b=COME&c=STAI%3F
     Output => "CIAO COME STAI?"
 */
app.MapGet("/", (string a = "", string b = "", string c = "") =>
    {
        //if (string.IsNullOrEmpty($"{a}{b}{c}") || string.IsNullOrWhiteSpace($"{a}{b}{c}"))
        if (string.IsNullOrEmpty($"{a}{b}{c}".Trim()))
            return "Mandami i tre pezzi del testo da concatenare!";
        return $"{a} {b} {c}";
    }
);

/*
 ES: Input => https://localhost:8800/CIAO/COME/STAI%3F
     Output => "CIAO COME STAI?"
 */

/*
 Creare una classe statica con una proprietà statica
 di tipo List<int>
 
 Creare un metodo GET che riceve un int in input di tipo Path
 e che aggiunge il valore alla lista

 Creare un metodo GET che restituisce l'intera lista di int
 
 Creare un metodo GET che restituisca la somma di tutti i valori
 */

app.MapGet("/{input}", (int input) => Data.Values.Add(input));

app.MapGet("/GetList", () => Data.Values);

app.MapGet("/Sum", () => Data.Values.Sum());

app.Run();
