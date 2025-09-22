import mongoose from "mongoose";

const memeSchema = new mongoose.Schema(
  {
    userId: { type: String, required: true, index: true },
    title: { type: String, required: true, trim: true },
    imageUrl: { type: String, required: true, trim: true }
  },
  { timestamps: true }
);

export default mongoose.model("Meme", memeSchema);
