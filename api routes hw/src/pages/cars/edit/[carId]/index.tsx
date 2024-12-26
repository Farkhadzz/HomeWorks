import axios from 'axios';
import { useRouter } from 'next/router';
import { useEffect, useState } from 'react';

export default function Edit() {
    const router = useRouter();
    const { carId } = router.query; 
    console.log(carId);
    const [car, setCar] = useState({
        brand: '',
        model: '',
        year: '',
        color: '',
        price: '',
    });
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        if (carId) {
            axios.get(`/api/cars/${carId}`)
                .then((response) => {
                    setCar(response.data);
                    setLoading(false);
                })
                .catch((err) => {
                    setError(err.message);
                    setLoading(false);
                });
        }
    }, [carId]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setCar((prevCar) => ({ ...prevCar, [name]: value }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.put(`/api/cars/${carId}`, car);
            router.push('/cars');
        } catch (err) {
            setError(err.response?.data || 'An error occurred');
        }
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div>
            <h1>Edit Car</h1>
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
                <button type="submit">Update Car</button>
            </form>
        </div>
    );
}
