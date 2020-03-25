const router = require("express").Router();
const userRoutes = require("./profile");
const CarRoutes = require("./car");
const forumRoutes = require("./forum");



router.use("/profile", userRoutes);
router.use("/car", CarRoutes);
router.use("/forum", forumRoutes);


module.exports = router;
