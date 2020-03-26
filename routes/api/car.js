
const router = require("express").Router();
const userController = require("../../controller/userController");

// Matches with "/api/car/

router.route("/user/:user")
    .get(userController.findOneJournal)


router.route("/")
    .get(userController.findAllJournals)
    .post(userController.createCar)

router.route("/id/:id")
    .delete(userController.removeJournal)
    .put(userController.updateJournal)
    .get(userController.findOneJournalById)
module.exports = router;