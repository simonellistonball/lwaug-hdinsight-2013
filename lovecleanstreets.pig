cleanstreetdata = load 'wasb://cluster@sebhdinsight.blob.core.windows.net/input/LoveCleanStreets.txt' using PigStorage('\t'); 
grouped = group cleanstreetdata by ($13,SUBSTRING($4,0,10)); 
count = foreach grouped generate group, COUNT(cleanstreetdata); 
store count into 'wasb://cluster@sebhdinsight.blob.core.windows.net/pigout/'; 