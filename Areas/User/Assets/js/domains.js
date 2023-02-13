const frameworks = [
    {
        name: "angular"
    },
    {
        name: "ember"
    },
    {
        name: "react"
    },
    {
        name: "vue"
    }
];

frameworks.forEach( framework => {
    const card = `<div class="card" style="width: 18rem;">
  <img class="card-img-top" src="assets/images/services/service_1.jpg?text=Image cap" alt="Card image cap">
  <div class="card-body">
    <h5 class="card-title">${framework.name}</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
</div>`
    const ele = document.createElement('div');
    ele.innerHTML = card;
    document.body.appendChild(ele.firstChild);
})