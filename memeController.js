import Meme from "../models/Meme.js";

export const createMeme = async (req, res) => {
  try {
    const { userId, title, imageUrl } = req.body;
    if (!userId || !title || !imageUrl) {
      return res.status(400).json({ message: "userId, title and imageUrl are required" });
    }
    const meme = await Meme.create({ userId, title, imageUrl });
    res.status(201).json(meme);
  } catch (err) {
    res.status(500).json({ error: "Server error", details: err.message });
  }
};

export const getMemes = async (req, res) => {
  try {
    const { userId } = req.query;
    const filter = userId ? { userId } : {};
    const memes = await Meme.find(filter).sort({ createdAt: -1 });
    res.json(memes);
  } catch (err) {
    res.status(500).json({ error: "Server error", details: err.message });
  }
};
