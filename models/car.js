
let mongoose = require("mongoose");
let Schema = mongoose.Schema;

let CarSchema = new Schema({
    make: { type: String, required: true },
    model: { type: String, required: true },
    year: { type: Number, required: true },
    condition: { type: String, required: true },
    createdAt: { type: Date, default: Date.now }
});

let Car = mongoose.model("Journal", CarSchema);

module.exports = Car;