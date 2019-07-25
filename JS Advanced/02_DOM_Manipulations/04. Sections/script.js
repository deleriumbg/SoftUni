function create(words) {
   const containerElement = document.getElementById('content');

   for (const word of words) {
      let divElement = document.createElement('div');
      let pElement = document.createElement('p');
      pElement.textContent = word;
      pElement.style.display = 'none';

      divElement.appendChild(pElement);
      divElement.addEventListener('click', function(){
         pElement.style.display = 'block';
      });
      containerElement.appendChild(divElement);
   }
}