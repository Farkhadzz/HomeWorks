import axios from "axios";
import Link from "next/link";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";

export default function Cars() {
  const [cars, setCars] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const getCars = async () => {
    try {
      const response = await fetch("/api/cars");
      const data = await response.json();
      setCars(data);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  const deleteCar = async (id: number) => {
    try {
      const response = await axios.delete(`/api/cars/${id}`);
      setCars((prevCars) => prevCars.filter((car) => car.id !== id));
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    getCars();
  }, []);

  if (loading) return <div className="loading">Loading...</div>;
  if (error) return <div className="error">Error: {error}</div>;

  return (
    <div>
      <h1>Cars</h1>
      {cars.length > 0 ? (
        cars.map((car) => (
          <div key={car.id} className="car-item">
            <h3>
              <Link href={`/cars/${car.id}`}>
                {car.brand} {car.model}
              </Link>
            </h3>

            <p>
              Year: {car.year}, Color: {car.color}, Price: {car.price}
            </p>
            <button onClick={() => deleteCar(car.id)}>Delete</button>
            <Link href={`/cars/edit/${car.id}`}>Edit car</Link>
          </div>
        ))
      ) : (
        <p>No cars.</p>
      )}
    </div>
  );
}
