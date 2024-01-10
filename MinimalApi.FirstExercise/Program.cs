using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.FirstExercise;
using MinimalApi.Library;
using System.Reflection.Metadata.Ecma335;

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

app.MapGet("/numbers/{input}", (int input) => Data.Values.Add(input));

app.MapGet("/numbers/GetList", () => Data.Values);

app.MapGet("/numbers/Sum", () => Data.Values.Sum());


app.MapPost("/Login", (Login login) =>
!(string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
    //{
    //    if(string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
    //    {
    //        return false;
    //    } 
    //    else
    //    {
    //        return true;
    //    }
    //}
    );

/*
 Creare una nuova classe chiamata Invoice con le seguenti proprietà:
 - Timestamp di tipo datetime nullable
        public DateTime? Timestamp { get; set; }
 - Amount di tipo decimal
 - Customer di tipo string

 Creare una nuova proprietà statica nella classe statica Data 
 di tipo List<Invoice>
 
 Creare un metodo POST che riceve un Invoice in input
 che valorizzi il campo Timestamp con Datetime.Now
 e che aggiunge l'oggetto alla lista di List<Invoice>

 Creare un metodo GET che restituisce l'intera lista di Invoice
 
 Creare un metodo GET che restituisca la somma di tutti i campi 
 Amount della lista
 */

app.MapPost("/Invoice", ([FromBody]Invoice invoice) =>
{
    invoice.Timestamp = DateTime.Now;
    Data.Invoices.Add(invoice);
    return $"{invoice}";
});

app.MapGet("/Invoice/All", () => Data.Invoices);

app.MapGet("/Invoices/Total", () =>
{
    //decimal tot = 0;
    //foreach(var invoice in Data.Invoices)
    //{
    //    tot += invoice.Amount;
    //}
    //return tot;

    return Data.Invoices.Sum((Invoice x) => x.Amount);
});
Person p = new Person();
app.Run();


