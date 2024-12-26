import { NextApiRequest, NextApiResponse } from "next";
import { cars } from '../../../data'

export default async function handler(req: NextApiRequest, res: NextApiResponse) {
    if (req.method === 'GET') {
        try {
            const { carId } = req.query;
            const selectedCar = cars.find(car => car.id === Number(carId));
            console.log(selectedCar);
            return res.status(200).json(selectedCar);
        } catch (error) {
            res.status(400).send({ error: error.message });
        }
    }
    
    if (req.method === 'DELETE') {
        try {
            const { carId } = req.query;
            if (req.method === "DELETE") {
                const carIndex = cars.findIndex((car) => car.id === parseInt(carId));
                if (carIndex > -1) {
                    cars.splice(carIndex, 1);
                    return res.status(200).json({ message: "Car deleted successfully." });
                }
            }
        } catch (error) {
            res.status(400).send({ error: error.message });
        }
    }


    if (req.method === 'PUT') {
        const { brand, model, year, color, price } = req.body;
        const { carId } = req.query;
        const carIndex = cars.findIndex((c) => c.id === Number(carId));
        if (carIndex === -1) return res.status(404).json({ message: 'Car not found' });
        cars[carIndex] = { ...cars[carIndex], brand, model, year: parseInt(year), color, price: parseFloat(price) };
        return res.status(200).json(cars[carIndex]);
    }

}
