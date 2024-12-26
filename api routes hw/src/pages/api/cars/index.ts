import { NextApiRequest, NextApiResponse } from "next";
import { cars } from "../../../data";

export default async function handler(
  req: NextApiRequest,
  res: NextApiResponse
) {
  if (req.method === "GET") {
    try {
      return res.status(200).json(cars);
    } catch (error) {
      res.status(400).send({ error: error.message });
    }
  }
  if (req.method === "POST") {
    try {
      const { brand, model, year, color, price } = req.body;
      const newCar = {
        id: cars.length + 1,
        brand,
        model,
        year: parseInt(year),
        color,
        price: parseFloat(price),
      };
      cars.push(newCar);
      res.status(201).json(newCar);
    } catch (error) {
      res.status(400).send({ error: error.message });
    }
  }
}
