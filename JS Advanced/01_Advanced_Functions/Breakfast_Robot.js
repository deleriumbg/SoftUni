function robot() {
    let ingredients = {
        protein: {
            name: 'protein',
            quantity: 0
        },
        carbohydrate: {
            name: 'carbohydrate',
            quantity: 0
        },
        fat: {
            name: 'fat',
            quantity: 0
        },
        flavour: {
            name: 'flavour',
            quantity: 0
        }
    };

    let mealCooking = {
        apple: (quantity) => useRequiredIngredients([
            { element: ingredients.carbohydrate, amount: quantity },
            { element: ingredients.flavour, amount: quantity * 2 }
        ]),
        lemonade: (quantity) => useRequiredIngredients([
            { element: ingredients.carbohydrate, amount: quantity * 10 },
            { element: ingredients.flavour, amount: quantity * 20 }
        ]),
        burger: (quantity) => useRequiredIngredients([
            { element: ingredients.carbohydrate, amount: quantity * 5 },
            { element: ingredients.fat, amount: quantity * 7 },
            { element: ingredients.flavour, amount: quantity * 3 }
        ]),
        eggs: (quantity) => useRequiredIngredients([
            { element: ingredients.protein, amount: quantity * 5 },
            { element: ingredients.fat, amount: quantity },
            { element: ingredients.flavour, amount: quantity }
        ]),
        turkey: (quantity) => useRequiredIngredients([
            { element: ingredients.protein, amount: quantity * 10 },
            { element: ingredients.carbohydrate, amount: quantity * 10 },
            { element: ingredients.fat, amount: quantity * 10 },
            { element: ingredients.flavour, amount: quantity * 10 }
        ]),
    };

    function useRequiredIngredients(requiredIngredients) {
        for (let i = 0; i < requiredIngredients.length; i++) {
            if (requiredIngredients[i].element.quantity < requiredIngredients[i].amount) {
                returnTakenElements(i);
                return `Error: not enough ${requiredIngredients[i].element.name} in stock`;
            }

            requiredIngredients[i].element.quantity -= requiredIngredients[i].amount;
        }

        return 'Success';

        function returnTakenElements(indexOfMissingElement) {
            for (let i = indexOfMissingElement - 1; i >= 0; i--) {
                requiredIngredients[i].element.quantity += requiredIngredients[i].amount;
            }
        }
    }

    let commands = {
        restock: (microelement, quantity) => {
            ingredients[microelement].quantity += Number(quantity);
            return 'Success';
        },
        prepare: (recipe, quantity) => {
            let meal = mealCooking[recipe.toLowerCase()];
            if (meal) {
                return meal(Number(quantity));
            }

            return `Error: recipe for ${recipe} does not exists!`;
        },
        report: () => Object.keys(ingredients)
            .map(name => `${name}=${ingredients[name].quantity}`)
            .join(' ')
    };

    return function (command) {
        if (command === undefined) {
            return;
        }

        let cmdTokens = command.split(' ');
        let cmd = commands[cmdTokens[0]];
        if (cmd) {
            return cmd(cmdTokens[1], cmdTokens[2]);
        }

        return 'Error: Command does not exists!';
    }
}