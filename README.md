# TariffComparison
Tariff Comparison is an Api to compare Electricity prices


Background
Suppose you are working on a platform to compare Electricity prices, where users can estimate their annual
cost based on consumption. Assume there is an external provider of Electricity Tariffs. Your job is to process
the user input and do the appropriate calculations depending on the tariff type.
This is an extract of the items returned by the Tariff Provider:
[
{"name": "Product A", "type": 1, "baseCost": 5, "additionalKwhCost": 22},
{"name": "Product B", "type": 2, "includedKwh": 4000, "baseCost": 800,
"additionalKwhCost": 30},
...
]
The type of product determines the calculation model as this
1. Product A
Type: “1 - basic electricity tariff”
Calculation model: base costs per month 5 € + consumption costs 22 cent/kWh. Examples:
• Consumption: 3500 kWh/year => Annual costs = 830 €/year (5€ * 12 months = 60 € base
costs + 3500 kWh/year * 22 cent/kWh = 770 € consumption costs)
• Consumption: 4500 kWh/year => Annual costs = 1050 €/year (5€ * 12 months = 60 € base
costs + 4500 kWh/year * 22 cent/kWh = 990 € consumption costs)

2. Product B
Type: “2 - Packaged tariff”
Calculation model: 800 € for up to 4000 kWh/year and above 4000 kWh/year additionally 30
cent/kWh. Examples:
• Consumption: 3500 kWh/year => Annual costs = 800 €/year
• Consumption: 4500 kWh/year => Annual costs = 950 €/year (800€ + 500 kWh * 30 cent/kWh
= 150 € additional consumption costs)

Task
Create a service to read the products from the Tariff Provider (you can mock it as you consider better), do the
calculations, and return the results, considering the following aspects:
• Develop a model to build up the two Products mentioned above, and to compare these products
based on their annual costs. The comparison should accept the following input parameter:
o Consumption (kWh/year)
• Return a list of the calculation results with at least the columns:
o Tariff name
o Annual costs (€/year)
• The list should be sorted by costs in ascending order
• Create a RESTful service to retrieve the results
• Consider there may be more products and product types
• Bonus point: set up a script to quickly install all application requirements and run it on team member
computers if they are running Linux
• Note: Please implement this task in C#, NodeJS or PHP