import zlib
import sys
import os

f = open(sys.argv[1], 'rb')
#print(-zlib.MAX_WBITS)
decompressed_data = f.read()

f.seek(0, os.SEEK_END)

pre = bytearray(decompressed_data)
processed = pre[pre.find(b'\x78\xDA'):]
processed_data = bytes(processed)
#print(''.join(format(x, '02x') for x in processed))

print("bytes: ", f.tell(), "crc: ", zlib.crc32(decompressed_data))

