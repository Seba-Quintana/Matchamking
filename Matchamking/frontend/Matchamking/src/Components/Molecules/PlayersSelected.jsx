import React from 'react'

const PlayersSelected = (selectedPlayers, setRemainingPlayers) => {
  return (
    <>
        {
            selectedPlayers.map(item => 
                <Player winrate={item.winrate}
                    playername={item.playername}
                    players={selectedPlayers}
                    setPlayers={setRemainingPlayers}
                ></Player>)
        }
    </>
  )
}

export default PlayersSelected