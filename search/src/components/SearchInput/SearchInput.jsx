import React, { useState } from 'react';

function SearchInput({ onSearch }) {
  const [searchText, setSearchText] = useState('');

  const handleInputChange = (e) => {
    const text = e.target.value.trim();
    setSearchText(text);
    onSearch(text);
  };

  return (
    <input
      type="text"
      value={searchText}
      onChange={handleInputChange}
      placeholder="Введите текст"
    />
  );
}

export default SearchInput;