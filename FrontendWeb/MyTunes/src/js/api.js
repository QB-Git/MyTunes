window.API = async (requete, callback = ((a) => {return a})) => {
    const response = await fetch(`https://mytunes20200429155409.azurewebsites.net/api/${requete}`);
    const json = await response.json();
    return callback(json);
}
