const express = require('express');
const cors = require('cors');
const app = express();
const port = 4000;

app.use(cors());

let photosArray = [
  { name: "Photo1", type: "jpeg", url: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSd73SCVcx2FeDIs_i_miOXKvqUiDbJ5uDc6w&s" },
  { name: "Photo2", type: "jpeg", url: "https://avatars.dzeninfra.ru/get-zen_doc/1879615/pub_64d810be9e590127fb06215c_64d81237892c0461188d3afd/scale_1200" },
];

app.get('/api/photos', (req, res) => {
  res.json(photosArray);
});

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
