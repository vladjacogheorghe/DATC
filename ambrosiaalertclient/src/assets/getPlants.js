export async function getPlants() {
    let plants;
    try {
        //https://ambrosiaalert.azurewebsites.net/
        const response = await fetch('https://localhost:7087/plants',//'https://ambrosiaalert.azurewebsites.net/plants', //
            {
                method: 'get',
                headers: {
                    'content-type': "application/json; charset=utf-8",
                }
            })
            plants = response.json();
    } catch (err) {
        console.log("Error: could not fetch Plants!"+err);
    }

    return plants;
}