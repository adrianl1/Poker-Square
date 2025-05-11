const fs = require('fs');

function squareUp(){
    //Check for any players that owe the exact amount that someone else made
    negatives.forEach(negative=>{
        positives.forEach(positive=>{
            if(Math.abs(negative.balance) == positive.balance){
                payments.push({
                    "player1": negative.name,
                    "player2": positive.name,
                    "amount": Math.abs(negative.balance)
                });
                negative.balance = 0;
                positive.balance = 0;
            }
        })
    });
    //Square up the rest
    negatives.forEach(negative=>{
        while(negative.balance < 0){
            for(positive of positives){
                if(positive.balance == 0){
                    continue;
                }
                else if(positive.balance > Math.abs(negative.balance)){
                    payments.push({
                        "player1": negative.name,
                        "player2": positive.name,
                        "amount": Math.abs(negative.balance)
                    });
                    positive.balance -= Math.abs(negative.balance);
                    negative.balance = 0;
                }
                else{
                    payments.push({
                        "player1": negative.name,
                        "player2": positive.name,
                        "amount": positive.balance
                    });
                    negative.balance += positive.balance;
                    positive.balance = 0;
                }
                break;
            }
        }
    });
    payments.forEach(payment=>{
        console.log(payment.player1 + " pays " + payment.player2 + " $" + payment.amount);
    });
}

function verifyChipCount(){
    let totalBuyIn = 0;
    let totalChipValue = 0;
    players.forEach(player=>{
        totalBuyIn += player.buyIn;
        totalChipValue += player.chipValue;
    });
    if(totalBuyIn != totalChipValue){
        console.log("VERIFY CHIP COUNT AND BUY IN VALUES:");
        console.log("Total buy in: $" + totalBuyIn);
        console.log("Total reported chip value: $" + totalChipValue);
        process.exit();
    }
}

function calculateDifferences(){
    players.forEach(player=>{
        //The difference should never change
        player.difference = player.chipValue - player.buyIn;
        //The balance is updated during the process of squaring up
        player.balance = player.difference;
        console.log(player.name + " balance: $" + player.difference);
        if (player.difference < 0){
            negatives.push(player);
        }
        else {
            positives.push(player);
        }
    });
}

// Read JSON file
let fileContent = fs.readFileSync('players.json', 'utf8');
// Parse the JSON data into an array of objects
let players = JSON.parse(fileContent);
let negatives = [];
let positives = [];
let payments = [];

verifyChipCount();

calculateDifferences();

//Sort lists
negatives.sort(function(a,b){
    return Math.abs(b.difference) - Math.abs(a.difference);
});
positives.sort(function(a,b){
    return b.difference - a.difference;
});

console.log('-----');
squareUp();