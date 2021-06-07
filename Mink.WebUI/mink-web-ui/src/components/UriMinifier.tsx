import React, {useState, useRef} from 'react';
import './UriMinifier.css'

function UriMinifier() {

  const inputUriRef = useRef<HTMLInputElement>(null);
  const outputUriRef = useRef<HTMLInputElement>(null);

  async function handleMinifyClick() {

    const inputUri = inputUriRef.current?.value
    const response = await window.fetch('https://localhost:5001/uri', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({originUri: inputUri}),
    });

    const {data, errors} = await response.json();
    // console.log(data, errors);
    if (response.ok) {
      if (outputUriRef.current)
        outputUriRef.current.value = `https://localhost:5001/r/${data.minifiedUriKey}`;
    }
  }

  return (
    <div>
      <label>Your uri: </label>
      <input ref={inputUriRef} type="text" />
      <button onClick={handleMinifyClick}>Minify</button>
      <br/>
      <label>Short uri: </label>
      <input ref={outputUriRef} type="text" />
    </div>
  );
}

export default UriMinifier;