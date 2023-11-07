import './App.css';
import { useState } from 'react';
import Results from './components/Results/Results';
import SearchInput from './components/SearchInput/SearchInput';

const data = ['Farkhad', 'test', 'task', 'barcelona'];

function App() {
  const [searchResults, setSearchResults] = useState(data);

  const handleSearch = (searchText) => {
    const trimmedText = searchText.trim();
    if (trimmedText === '') {
      setSearchResults(data);
    } else {
      const filteredResults = data.filter((result) =>
        result.includes(trimmedText)
      );
      setSearchResults(filteredResults);
    }
  };

  return (
    <div>
      <SearchInput onSearch={handleSearch} />
      <Results searchResults={searchResults} />
    </div>
  );
}

export default App;
