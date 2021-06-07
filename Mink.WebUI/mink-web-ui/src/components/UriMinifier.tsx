import React, {useState, useRef} from 'react';
import './UriMinifier.css'

function UriMinifier() {

  const inputUriRef = useRef<HTMLInputElement>(null);

  function handleMinifyClick() {

    const inputUri = inputUriRef.current?.value

    fetch('https://localhost:5001/uri', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
        // 'Access-Control-Allow-Origin': '*',
      },
      body: JSON.stringify({originUri: inputUri, minifiedUri: ""}),
    })
      // .then(response => response.json())
      .then(data => {
        console.log(data);
      });
  }

  return (
    <div>
      <input ref={inputUriRef} type="text" />
      <button onClick={handleMinifyClick}>Minify</button>
    </div>
  );
}

export default UriMinifier;