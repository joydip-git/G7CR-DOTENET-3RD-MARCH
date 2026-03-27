import { useEffect, useState } from "react"

const Sample = () => {
    const [messageData, setMessageData] = useState<string>('not yet fetched...')
    const [loadingOver, setLoadingOver] = useState(false)
    const [errorMessage, setErrorMessage] = useState('')
    const fetchMessage = async () => {
        try {
            const res: Response = await fetch("http://localhost:5011/api/values/welcome")
            const data = await res.json()
            console.log(data);
            setMessageData(data.message)
            setErrorMessage('')
            setLoadingOver(true)
        } catch (error: any) {
            setMessageData('NA')
            setErrorMessage(error.message)
            setLoadingOver(true)
        }
    }
    useEffect(
        () => {
            fetchMessage()
        },
        []
    )
    if (!loadingOver)
        return <span>loading...</span>
    else if (errorMessage !== '')
        return <span>{errorMessage}</span>
    else if (!messageData)
        return <span>No message</span>
    else
        return <div>{messageData}</div>
}

export default Sample