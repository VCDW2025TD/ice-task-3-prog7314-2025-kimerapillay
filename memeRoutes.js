import { Router } from "express";
import { createMeme, getMemes } from "../controllers/memeController.js";

const router = Router();
router.get("/", getMemes);
router.post("/", createMeme);

export default router;
