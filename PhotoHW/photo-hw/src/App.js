import React, { useEffect, useState } from 'react';
import axios from 'axios';

function App() {
  const [photos, setPhotos] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:4000/api/photos')
      .then(response => {
        setPhotos(response.data);
      })
      .catch(error => {
        console.error('Error fetching photos:', error);
      });
  }, []);

  return (
    <div>
      <h1>Photo Gallery</h1>
      <div className="photo-list">
        {photos.map((photo, index) => (
          <div key={index} className="photo-item">
            <img src={photo.url} alt={photo.name} />
          </div>
        ))}
      </div>
    </div>
  );
}

export default App;
