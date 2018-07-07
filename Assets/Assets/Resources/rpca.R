setwd("D:/UFRGS/projeto/homework/csv")
data1.origin <- read.csv("music_fix.csv",header=T) 
data1.data <- data1.origin[,1:4]
data1.data$duration <- data1.data$duration/60
attach(data1.data)
arthot <- data1.data[,1]
tempo <- data1.data[,2]
fam <- data1.data[,3]
duration <- data1.data[,4]

terms <- data1.data[,7]
data1.data$artist.hotttnesss <- (arthot - mean(arthot)) / sd(arthot)
data1.data$tempo <- (tempo - mean(tempo)) / sd(tempo)
data1.data$familiarity <- (fam - mean(fam)) / sd(fam)
data1.data$duration <- (duration - mean(duration)) / sd(duration)

data1.data$loudness <- (loudness - mean(loudness)) / sd(loudness)

data1.pca <- prcomp(data1.data[,1:4],scale=T)
data1.pcax <- data1.pca$x
data1.pcax <- cbind(data1.pcax,term="a")


write.csv(data1.pcax, file = "MyData.csv")





data1.pca <- prcomp(data1.data[,-7],scale = T)


fviz_pca_ind(data1.pca,
             geom.ind = "point", # show points only (nbut not "text")
             col.ind = data1.data$terms, # color by groups
                          addEllipses = TRUE, # Concentration ellipses
             legend.title = "Groups"
             )
			 
			 
		
 data1.subdataset2 <- read.csv("msd-subdataset2.csv",header=T)

write.csv(data1.subdataset1, file = "msd-subdataset1.csv")
 

=================================================================== 
 
j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "pop" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "soul and reggae" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "folk" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "hip-hop" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "punk" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "dance and electronica" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "classic pop and rock" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "jazz and blues" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "classical" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}

j = 1
for (i in 1:59600){
	
	if(data1.origin[i,4] %in% "metal" ) {
		data1.subdataset5[ nrow(data1.subdataset5) + 1,] = data1.origin[i,]
		j = j + 1
	}
	
	if(j == 501)
		break
	
}



data1.origin$track_id = as.character(data1.origin$track_id)
data1.origin$artist_name = as.character(data1.origin$artist_name)
data1.origin$genre = as.character(data1.origin$genre)
data1.origin$title = as.character(data1.origin$title)