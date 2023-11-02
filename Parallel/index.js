(async () => {
    const headerPromise = fetch('/components/header/header.html');
    const footerPromise = fetch('/components/footer/footer.html');
  
    const [headerResponse, footerResponse] = await Promise.all([headerPromise, footerPromise]);
  
    console.log(headerResponse);
    console.log(footerResponse);
  
    const headerHTMLText = await headerResponse.text();
    const footerHTMLText = await footerResponse.text();
  
    console.log(headerHTMLText);
    console.log(footerHTMLText);
  
    document.body.insertAdjacentHTML('afterbegin', headerHTMLText);
    document.body.insertAdjacentHTML('beforeend', footerHTMLText);
  })();