import React from 'react';
import Result from '../Result/Result';

function Results({ searchResults }) {
  return (
    <ul>
      {searchResults.map((result, index) => (
        <Result key={index} text={result} />
      ))}
    </ul>
  );
}

export default Results;