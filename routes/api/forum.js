const router = require("express").Router();
const userController = require("../../controller/userController");

// Matches with "/api/forum/

router.route("/")
    .get(userController.showAllPosts)
    .post(userController.createPost)

// Matches with "/api/forum/:id"
router
    .route("/:id")
    .get(userController.getComments)
    .put(userController.createComment);

module.exports = router;