import SendRequest from "../SendRequest";
import NotificationAlert from "./NotificationAlert";

const MainPage = () => {
  
  return (
    <>
    <div className="p-4">
      <div className="mb-4">
        <NotificationAlert/>
        <SendRequest/>
      </div>
    </div>
    </>
  );
};

export default MainPage;
