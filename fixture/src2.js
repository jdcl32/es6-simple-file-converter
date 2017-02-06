smeagol = {
    precious: function() {
        return "ring"
    },
    doWeHate: function(target) {
        var random = Math.floor(Math.random() * 11);
        return target === "Frodo" && random % 2 === 0;
    },
    isFood: function (food) {
        return ["hobbit","orc","fish"].includes(food);
    }
}