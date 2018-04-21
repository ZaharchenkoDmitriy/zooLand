(() => {
  fetch("http://localhost:3000/animals").then((data) => {
    data.json().then(res=>{
      console.log(res);
    })
  } )
})();
