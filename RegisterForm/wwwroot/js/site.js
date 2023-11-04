document.querySelector('form').addEventListener('change', function (e) {
    const errorMessages = document.getElementById('error-messages');
    errorMessages.innerHTML = ''; 

    const fields = {
        Imie: { minLen: 2, message: 'Imie musi zawierać co najmniej 2 znaki' },
        Nazwisko: { minLen: 2, message: 'Nazwisko musi zawierać co najmniej 2 znaki' },
        Wiek: { min: 11, max: 80, message: 'Wiek musi być pomiędzy 11 a 80' },
        Email: { pattern: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/, message: 'Podaj poprawny email' },
        Haslo: { pattern: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$/, message: 'Hasło musi zawierać co najmniej jedną cyfrę, jedną dużą literę i jedną małą literę' },
        PotwierdzenieHasla: { equalTo: 'Haslo', message: 'Potwierdzenie hasła musi być identyczne z hasłem' },
        Miasto: { values: ['Warszawa', 'Kraków', 'Poznań', 'Wrocław', 'Gdańsk'], message: 'Wybierz poprawne miasto' }
    };

    let isValid = true;

    for (const name in fields) {
        const field = document.querySelector(`[name="${name}"]`);
        const value = field.value;
        const validation = fields[name];

        if ('minLen' in validation && value.length < validation.minLen && value !== "") {
            errorMessages.innerHTML += `<p>${validation.message}</p>`;
            isValid = false;
        }

        if ('min' in validation && value < validation.min && value !== "") {
            errorMessages.innerHTML += `<p>${validation.message}</p>`;
            isValid = false;
        }

        if ('max' in validation && value > validation.max && value !== "") {
            errorMessages.innerHTML += `<p>${validation.message}</p>`;
            isValid = false;
        }

        if ('pattern' in validation && !validation.pattern.test(value) && value !== "") {
            errorMessages.innerHTML += `<p>${validation.message}</p>`;
            isValid = false;
        }

        if ('equalTo' in validation) {
            const otherField = document.querySelector(`[name="${validation.equalTo}"]`);
            if (value !== otherField.value) {
                errorMessages.innerHTML += `<p>${validation.message}</p>`;
                isValid = false;
            }
        }

        if ('values' in validation && !validation.values.includes(value)) {
            errorMessages.innerHTML += `<p>${validation.message}</p>`;
            isValid = false;
        }
    }
});