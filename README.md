# B3
Este projeto é estritamente para estudos. Estou criando uma API simulando as operações feitas na Bolsa de Valores especialmente para fins de aprendizagem.

# Objetivos
Este projeto inicialmente conterá dois microserviços de Ordens e o de Livro de Ofertas. Os mesmos irão rodar em cima do docker e tentarei aplicar o Kubernetes no projeto também.

# Possíveis ações no sistema

## Ordens
### Envio de ordem
```
POST: <domínio>/api/ordens/enviaordem
Body:
{
    "CodigoPapel": "TSLA34",
    "Valor": 119.56,
    "Quantidade": 200,
    "CPF": "74399934034",
    "TipoOrdem": 1
}
```

### Cancelamento de ordem
```
POST: <domínio>/api/ordens/cancelaordem
Body:
{
    "Id": 1057,
    "CPF": "74399934034"
}
```

### Lista ordens
```
GET: <domínio>/api/ordens/listaordens
Body:
{
    "CPF": "74399934034",
    "DataInicioIntervalo": "2021-09-01",
    "DataFimIntervalo": "2021-09-13"
}
```
