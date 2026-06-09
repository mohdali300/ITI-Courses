# gRPC — Orders Solution

A .NET 10 gRPC simple demo, with a browser-based JS client.

## Projects

| Project | Type | Port |
|---|---|---|
| `Orders.API` | ASP.NET Web API + gRPC-Web server | 5100 |
| `Inventory.Service` | gRPC server | 5200 |
| `Payment.Service` | gRPC server | 5300 |
| `JS-Client` | Static HTML/JS (gRPC-Web client) | — |

## Architecture

```
Browser (JS) --[gRPC-Web]--> Orders.API --[gRPC]--> Inventory.Service --[gRPC]--> Payment.Service
```

The JS client sends a `CreateOrder` request via gRPC-Web. Orders.API processes it by calling both downstream gRPC services — deducting inventory stock and user balance — then returns the result.

## Running the Solution

Start each service in a separate terminal:

```bash
cd Inventory.Service && dotnet run
cd Payment.Service  && dotnet run
cd Orders.API       && dotnet run
```

Then open `JS-Client/index.html` in a browser (or serve it):

```bash
cd JS-Client && npx serve .
```

## Testing via Swagger

With Orders.API running, navigate to:

```
http://localhost:5100/swagger
```

Sample request body for `POST /Order`:

```json
{
  "id": 1,
  "userId": "user-1",
  "items": [
    { "itemId": 1, "quantity": 2 },
    { "itemId": 1, "quantity": 1 }
  ]
}
```

## JS Client — Build

```bash
cd JS-Client
npm install
npx webpack ./client.js --output-path ./dist --output-filename bundle.js --mode development
```

> `node_modules/` and `dist/` are gitignored — run the above after cloning.

## Proto Files

| File | Service | Methods |
|---|---|---|
| `order.proto` | Order | `CreateOrder` |
| `inventory.proto` | Inventory | `DeductQuantity` |
| `payment.proto` | Payment | `DeductBalance` |


---

###### This is educational task.