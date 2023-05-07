import Form from "react-bootstrap/Form";
import TextInput from "../common/textInput";
import { useState } from "react";

function Writer({ text }) {
  const [value, setValue] = useState("");
  const [isValid, setIsValid] = useState(true);
  const [errorsCount, setErrorsCount] = useState(0);

  const handleChange = (e) => {
    const value = e.target.value;
    const qwe = text.slice(0, value.length);

    if (qwe === value) {
      setIsValid(true);
    } else {
      if (isValid) setErrorsCount((prev) => prev + 1);
      setIsValid(false);
    }

    setValue(e.target.value);
  };

  return (
    <>
      <TextInput value={value} onChange={handleChange} isValid={isValid} />
      <h3>{`Errors count: ${errorsCount}.`}</h3>
    </>
  );
}

export default Writer;
