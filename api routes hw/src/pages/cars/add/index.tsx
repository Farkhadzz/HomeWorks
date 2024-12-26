import axios from 'axios';
import { useState } from 'react';
import { useRouter } from 'next/router';

export default function Add() {
    const [car, setCar] = useState({
        brand: '',
        model: '',
        year: '',
        color: '',
        price: '',
    });
    const [error, setError] = useState(null);
    const router = useRouter();

    const handleChange = (e) => {
        const { name, value } = e.target;
        setCar((prevCar) => ({ ...prevCar, [name]: value }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('/api/cars', car);
            router.push('/cars'); 
        } catch (err) {
            setError(err.response?.data || 'An error occurred');
        }
    };

    return (
        <div>
            <h1>Add a New Car</h1>
            {error && <p>{error}</p>}
            <form onSubmit={handleSubmit}>
                <label>
                    Brand:
                    <input type="text" name="brand" value={car.brand} onChange={handleChange} required />
                </label>
                <label>
                    Model:
                    <input type="text" name="model" value={car.model} onChange={handleChange} required />
                </label>
                <label>
                    Year:
                    <input type="number" name="year" value={car.year} onChange={handleChange} required />
                </label>
                <label>
                    Color:
                    <input type="text" name="color" value={car.color} onChange={handleChange} required />
                </label>
                <label>
                    Price:
                    <input type="number" name="price" value={car.price} onChange={handleChange} required />
                </label>
                <button type="submit">Add Car</button>
            </form>
        </div>
    );
}
