function solve(arr) {
    let totalSum = 0;

    for (let i = 0; i < arr.length; i++) {
        let order = arr[i].split(", ");

        let drinkPrice = 0;
        let coin = Number(order[0]);
        let drinkType = order[1];
        let sugar = 0;
        let neededMoney = 0;

        if(drinkType === 'coffee'){
            let caffeineOrDecaf = order[2];

            if(caffeineOrDecaf === 'caffeine'){
                drinkPrice = 0.8;
            }
            else {
                drinkPrice = 0.9;
            }

            if(order.length === 5){
                sugar = Number(order[4]);
                neededMoney = drinkPrice + Number((drinkPrice * 0.1).toFixed(1));
                if(sugar !== 0){
                    neededMoney += 0.1;
                }
            }
            else {
                sugar = Number(order[3]);
                neededMoney = drinkPrice;

                if(sugar !== 0){
                    neededMoney += 0.1;
                }
            }
        }
        else {
            drinkPrice = 0.8;

            if(order.length === 4){
                sugar = Number(order[3]);

                neededMoney = drinkPrice + Number((drinkPrice * 0.1).toFixed(1));

                if(sugar !== 0){
                    neededMoney += 0.1;
                }
            }
            else {
                sugar = Number(order[2]);

                neededMoney = drinkPrice;

                if(sugar !== 0){
                    neededMoney += 0.1;
                }
            }
        }

        if(coin >= neededMoney){
            totalSum += neededMoney;
            console.log(`You ordered ${drinkType}. Price: ${neededMoney.toFixed(2)}$ Change: ${(coin - neededMoney).toFixed(2)}$`);
        }
        else {
            console.log(`Not enough money for ${drinkType}. Need ${(neededMoney - coin).toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalSum.toFixed(2)}$`)
}

solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']
);