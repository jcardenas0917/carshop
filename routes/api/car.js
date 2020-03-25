
const router = require("express").Router();
const userController = require("../../controller/userController");

// Matches with "/api/journal/

router.route("/user/:user")
    .get(userController.findOneJournal)


router.route("/")
    .get(userController.findAllJournals)
    .post(userController.createJournal)

router.route("/id/:id")
    .delete(userController.removeJournal)
    .put(userController.updateJournal)
    .get(userController.findOneJournalById)
module.exports = router;