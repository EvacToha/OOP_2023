import TextInput from "../components/common/textInput";
import Writer from "../components/writer";

function WriterPage() {
  const text = "Я ебал, меня сосали";

  return (
    <>
      <TextInput isDisabled={true} value={text} />
      <Writer text={text} />
    </>
  );
}

export default WriterPage;
